import { Component } from '@angular/core';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';
import { faArrowCircleRight } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-current-progress',
  templateUrl: './current-progress.component.html',
  styleUrls: ['./current-progress.component.css']
})
export class CurrentProgressComponent {
  arrowLeftIcon = faArrowAltCircleLeft;
  arrowRightIcon = faArrowAltCircleRight;

  data = {
    labels: ['.Net', 'C#', 'Angular', 'Softskill', '.Net essential'],
    datasets: [{
      label: 'Training progress',
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
