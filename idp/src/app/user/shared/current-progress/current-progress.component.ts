import { Component } from '@angular/core';

@Component({
  selector: 'app-current-progress',
  templateUrl: './current-progress.component.html',
  styleUrls: ['./current-progress.component.css']
})
export class CurrentProgressComponent {
  data = {
    labels: ['.Net', 'C#', 'Angular', 'Softskill', '.Net essential'],
    datasets: [{
      label: 'Objectives progress',
      data: [12, 19, 3, 5, 2],
      borderWidth: 2,
      borderColor: '#A162F7',
      backgroundColor: '#A162F7',
    }]
  }

  options = {
    scales: {
      y: {
        beginAtZero: true
      }
    },
  }

}
