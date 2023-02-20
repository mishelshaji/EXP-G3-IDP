import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionService } from 'src/app/service/action.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { TrainingService } from 'src/app/service/training.service';

@Component({
  selector: 'app-objective-detailed',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './objective-detailed.component.html',
  styleUrls: ['./objective-detailed.component.css']
})
export class ObjectiveDetailedComponent {
  edit: boolean = false;

  objectiveId: number = 0;

  editProgress() {
    this.edit = true;
  }

  submitProgress() {
    this.edit = false
  }

  /**
 * This is the list of action that will be displayed in the UI.
 * It will be initialized in the ngOnInit method. The default value is null.
 */
  action: ActionViewDto[] | null = null;

  /**
 * This is the list of training that will be displayed in the UI.
 * It will be initialized in the ngOnInit method. The default value is null.
 */
  training: TrainingViewDto[] | null = null;

  /**
   * @param service This is the instance of ActionService that will be used to
   */
  constructor(private actionService: ActionService, private trainingService: TrainingService,
    private router: ActivatedRoute) {

  }

  /**
   * This method will be called when the component is initialized. It will
   * fetch the list of action from the server. The list will be stored
   * in the action property. If the server returns an error, an alert
   * will be displayed to the user.
   */
  ngOnInit() {
    this.objectiveId = this.router.snapshot.params["id"];
    this.trainingService.getByObjective(this.objectiveId).subscribe({
      next: (data: TrainingViewDto[] | null) => {
        this.training = data;
        console.log(this.training);
      },
      error: () => {
        alert("Loading training failed. Please try again later.");
      }
    });

    this.actionService.getByObjective(this.objectiveId).subscribe({
      next: (data: ActionViewDto[] | null) => {
        this.action = data;
        console.log(this.action);
      },
      error: () => {
        alert("Loading action failed. Please try again later.");
      }
    });
  }
}
