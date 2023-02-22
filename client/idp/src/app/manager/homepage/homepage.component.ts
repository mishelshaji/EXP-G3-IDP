import { Component, OnInit } from '@angular/core';
import { ObjectivePendingService } from 'src/app/service/objectivePending.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
})
export class HomepageComponent implements OnInit {
  selectedStatus = 3;

  counters = [
    { name: 'Total Empolyees', count: 1000, limit: 1500 },
    { name: 'Total Created IDP', count: 0, limit: 126 },
    { name: 'Total Pending IDP', count: 0, limit: 600 },
    { name: 'Total Completed IDP', count: 0, limit: 660 }
  ];

  constructor(private objectivdePending: ObjectivePendingService){}

  intervalIds: any[] = [];

  objectivePending: PendingObjectiveDto[] | null = null;

  ngOnInit() {
    this.startCounters();
    
    this.objectivdePending.getPending().subscribe({
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

  onApprove() {
    
    this.resultMessage = 'Approved';
  }

  onReject() {
    this.resultMessage = 'Rejected';
  }
}
