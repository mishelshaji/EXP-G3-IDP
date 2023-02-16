import { Component } from '@angular/core';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';
import { TrainingService } from 'src/app/service/training.service';

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
  constructor(private trainingService: TrainingService) {

  }

  ngOnInit() {
    this.trainingItem = this.trainingService.getAll();
    this.trainingItem.forEach(element => {
      this.trainingName.push(element.name);
      this.trainingProgress.push(element.progress);
    })
  }

  

  data = {
    labels: this.trainingName,
    datasets: [{
      label: 'Objective progress',
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

  scrollLeft() {
    this.progressId = this.progressId - 1;
  }

  scrollRight() {
    this.progressId = this.progressId + 1;
  }
}
