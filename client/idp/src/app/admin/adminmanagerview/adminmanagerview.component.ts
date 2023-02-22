import { Component, OnInit } from '@angular/core';
import { ObjectivePendingService } from 'src/app/service/objectivePending.service';
import { ObjectiveUpdateService } from 'src/app/service/objectiveUpdate.service';

@Component({
  selector: 'app-adminmanagerview',
  templateUrl: './adminmanagerview.component.html',
  styleUrls: ['./adminmanagerview.component.css'],
})
export class AdminmanagerviewComponent {
  selectedStatus = 3;

  counters = [
    { name: 'Total Empolyees', count: 1000, limit: 1500 },
    { name: 'Total Created IDP', count: 0, limit: 126 },
    { name: 'Total Pending IDP', count: 0, limit: 600 },
    { name: 'Total Completed IDP', count: 0, limit: 660 }
  ];

  constructor(private objectivePendingService: ObjectivePendingService,
    private objectiveUpdate: ObjectiveUpdateService) { }

  intervalIds: any[] = [];

  objectivePending: PendingObjectiveDto[] | null = null;

  ngOnInit() {
    this.startCounters();

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
      },
      error: (error) => {
        console.error(error);
        alert("Error accepting objective");
      }
    });
    this.resultMessage = 'Rejected';
  }
}
