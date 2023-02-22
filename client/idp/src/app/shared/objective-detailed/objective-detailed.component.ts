import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionService } from 'src/app/service/action.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { TrainingService } from 'src/app/service/training.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-objective-detailed',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './objective-detailed.component.html',
  styleUrls: ['./objective-detailed.component.css']
})
export class ObjectiveDetailedComponent {
  edit: string = '';
  id: number = 0;

  model = {
    progress: 0
  }

  objectiveId: number = 0;

  actionLength: number = 0;
  trainingLength: number = 0;

  editProgress(id: number, section: string) {
    this.id = id;
    this.edit = section;
  }

  submitProgress(id: number) {
    if (this.edit == 'training') {
      var item:TrainingUpdateDto = {
        progress: this.model.progress
      };
      this.trainingService.update(id, item).subscribe({
        next: () => {
          alert("Training updated successfully");
        },
        error: (error) => {
          console.error(error);
          alert("Error updating training");
        }
      });

    } else {
      var item:ActionUpdateDto = {
        progress: this.model.progress
      };
      this.actionService.update(id, item).subscribe({
        next: () => {
          alert("Training updated successfully");
        },
        error: (error) => {
          console.error(error);
          alert("Error updating training");
        }
      });
    }

    this.edit = '';
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
      next: (data: TrainingViewDto[]) => {
        this.training = data;
        this.trainingLength = data?.length;
        console.log(this.training);
      },
      error: () => {
        alert("Loading training failed. Please try again later.");
      }
    });

    this.actionService.getByObjective(this.objectiveId).subscribe({
      next: (data: ActionViewDto[]) => {
        this.action = data;
        this.actionLength = data?.length;
        console.log(this.action);
      },
      error: () => {
        alert("Loading action failed. Please try again later.");
      }
    });
  }
}
