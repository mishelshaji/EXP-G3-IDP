import { Component } from '@angular/core';
import { faArrowAltCircleLeft, faArrowAltCircleRight } from '@fortawesome/free-regular-svg-icons';
import { HomepageService } from 'src/app/service/homepage.service';

@Component({
  selector: 'app-current-progress',
  templateUrl: './current-progress.component.html',
  styleUrls: ['./current-progress.component.css']
})
export class CurrentProgressComponent {
  progressId: number = 0;
  trainingName: string[] = [];
  trainingProgress: number[] = [];

  trainingItem: any[] = [];
  constructor(
  private progress: HomepageService,
  ) { }

  objectiveProgress: HomePageDto[] | null = null;

  idpName: string[] = ['.Net expert', 'Expert in Angular', '.Net advanced', 'node expert', 'become good at preesentation'];

  progress1: number[] = [];
  progressName: string[] = [];

  ngOnInit() {
    this.progress.getProgress(new Date().getFullYear()).subscribe({
      next: (data: any) => {
        this.objectiveProgress = data.result;
        this.objectiveProgress?.forEach(e =>{
            console.log(e.progress);  
            this.progress1.push(parseInt(e.progress));
            this.progressName.push(e.name);
          });
      },
      error: (error) => {
        console.log(error);
        console.log("Loading progress failed. Please try again later.");        
      }
    });
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
