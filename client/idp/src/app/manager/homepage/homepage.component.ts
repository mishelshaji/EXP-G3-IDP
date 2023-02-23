import { Component, OnInit } from '@angular/core';
import { GetManagerHomeProgressService } from 'src/app/service/GetManagerHomeProgress.service';
import { ObjectivePendingService } from 'src/app/service/objectivePending.service';
import { ObjectiveUpdateService } from 'src/app/service/objectiveUpdate.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
})
export class HomepageComponent implements OnInit {
  selectedStatus = 3;

  
  constructor(private objectivePendingService: ObjectivePendingService,
    private counterValue: GetManagerHomeProgressService,
    private objectiveUpdate: ObjectiveUpdateService) { }
    
    intervalIds: any[] = [];
    
    objectivePending: PendingObjectiveDto[] | null = null;
    
    progress: GetManagerHomeProgressDto | null = null;

    counters:any = [];

  ngOnInit() {
    
    this.objectivePendingService.getPending().subscribe({
      next: (data) => {
        this.objectivePending = data;
        console.log(this.objectivePending);
      },
      error: (error) => {
        console.log(error);
        console.log("Loading pending failed. Please try again later.");
      }
    });
    
    
    this.counterValue.getValue().subscribe({
      next: (data) => {
        this.progress = data;
        console.log(data);
        this.counters = [
          { name: 'Total Empolyees', count: this.progress?.totalEmployee, limit: 100000 },
          { name: 'Total Created IDP', count: this.progress?.totalCreatedIdp, limit: 100000 },
          { name: 'Total Objective', count: this.progress?.totalObjective, limit:  100000},
          { name: 'Total pending Objectives', count: this.progress?.totalPendingObjective, limit: 100000 }
        ];
      },
      error: (error) => {
        console.log(error);
        console.log("Loading pending failed. Please try again later.");
      }
    });
    this.startCounters();
  }

  startCounters() {
    for (let i = 0; i < this.counters.length; i++) {
      this.intervalIds[i] = setInterval(() => {
        if (this.counters[i].count === this.counters[i].limit) {
          clearInterval(this.intervalIds[i]);
        } else {
          this.counters[i].count++;
        }
      }, 0.01);
    }
  }

  resultMessage: string = '';

  onApprove(id:number) {
    var item: ObjectiveUpdateDto = {
      status: 2
    };
    this.objectiveUpdate.update(id, item).subscribe({
      next: () => {
        alert("Approved objective");
        window.location.reload();
      },
      error: (error) => {
        console.error(error);
        alert("Error accepting objective");
      }
    });
    this.resultMessage = 'Approved';
  }

  onReject(id:number) {
    var item: ObjectiveUpdateDto = {
      status: 0
    };
    this.objectiveUpdate.update(id, item).subscribe({
      next: () => {
        alert("Rejected objective");
        window.location.reload();
      },
      error: (error) => {
        console.error(error);
        alert("Error accepting objective");
      }
    });
    this.resultMessage = 'Rejected';
  }
}
