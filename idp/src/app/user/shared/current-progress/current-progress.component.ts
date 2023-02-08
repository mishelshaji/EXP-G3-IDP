import { Component } from '@angular/core';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-current-progress',
  templateUrl: './current-progress.component.html',
  styleUrls: ['./current-progress.component.css']
})
export class CurrentProgressComponent {
  progressId: number = 0;

  arrowLeftIcon = faArrowAltCircleLeft;
  arrowRightIcon = faArrowAltCircleRight;

  trainingItem = [
    { id: 1, name: 'Angular', description: "Angular description", },
    { id: 2, name: '.Net', description: ".Net description", },
    { id: 3, name: 'C#', description: "C# description", },
    { id: 4, name: 'SoftSkill', description: "SoftSkill description", },
    { id: 5, name: '.Net essential', description: ".Net essential description", }
  ];

  data = {
    labels: ['.Net', 'C#', 'Angular', 'Softskill', '.Net essential'],
    datasets: [{
      label: 'IDP progress',
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

  scrollLeft() {
    this.progressId = this.progressId - 1;
  }

  scrollRight() {
    this.progressId = this.progressId + 1;
  }
}
