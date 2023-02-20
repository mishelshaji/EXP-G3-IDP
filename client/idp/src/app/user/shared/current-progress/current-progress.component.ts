import { Component } from '@angular/core';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-current-progress',
  templateUrl: './current-progress.component.html',
  styleUrls: ['./current-progress.component.css']
})
export class CurrentProgressComponent {
  progressId: number = 0;
  trainingName: string[] = [];
  trainingProgress: number[] = [];

  arrowLeftIcon = faArrowAltCircleLeft;
  arrowRightIcon = faArrowAltCircleRight;

  trainingItem: any[] = [];
  constructor() {

  }

  idpName: string[] = ['.Net expert', 'Expert in Angular', '.Net advanced', 'node expert', 'become good at preesentation'];

  ngOnInit() {
    this.trainingItem.forEach(element => {
      this.trainingName.push(element.name);
      this.trainingProgress.push(element.progress);
    })
  }

  data = {
    labels: this.idpName,
    datasets: [{
      label: 'IDP progress',
      data: this.trainingProgress,
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
