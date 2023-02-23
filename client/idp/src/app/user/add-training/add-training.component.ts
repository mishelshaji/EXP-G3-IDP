import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  currentDate = new Date().toISOString().split('T')[0];

  constructor(
    private service: TrainingService,
    private router: ActivatedRoute,
    private navigate: Router) { }

  ngOnInit() {
    this.model.objectiveId = this.router.snapshot.params["id"];
  }

  createTraining() {
    this.service.create(this.model).subscribe({
      next: () => {
        alert("Training created successfully");
        return this.navigate.navigate(['user', 'objective-detailed', this.model.objectiveId]);
      },
      error: (error) => {
        console.error(error);
        alert("Error creating training");
      }
    })
  }
}
