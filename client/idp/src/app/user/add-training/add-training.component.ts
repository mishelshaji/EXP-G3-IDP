import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TrainingService } from 'src/app/service/training.service';

@Component({
  selector: 'app-add-training',
  templateUrl: './add-training.component.html',
  styleUrls: ['./add-training.component.css']
})
export class AddTrainingComponent {
  model = {
    objectiveId: 0,
    description: '',
    progress: 0,
    name: '',
    startDate: new Date(),
    endDate: new Date(),
    link: '',
  }

  constructor(
    private service: TrainingService,
    private router: ActivatedRoute) { }

  ngOnInit() {
    this.model.objectiveId = this.router.snapshot.params["id"];
  }

  createTraining() {
    console.log(this.model);
    this.service.create(this.model).subscribe({
      next: () => {
        alert("Training created successfully");
      },
      error: (error) => {
        console.error(error);
        alert("Error creating training");
      }
    })
  }
}
