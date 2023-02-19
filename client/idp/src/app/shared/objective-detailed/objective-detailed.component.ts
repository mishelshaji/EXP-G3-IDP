import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActionService } from 'src/app/service/action.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-objective-detailed',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './objective-detailed.component.html',
  styleUrls: ['./objective-detailed.component.css']
})
export class ObjectiveDetailedComponent {
  edit: boolean = false;

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
     * @param service This is the instance of ActionService that will be used to
     */
    constructor(private service: ActionService) {
  
    }
  
    /**
     * This method will be called when the component is initialized. It will
     * fetch the list of action from the server. The list will be stored
     * in the action property. If the server returns an error, an alert
     * will be displayed to the user.
     */
    ngOnInit() {
      this.service.getAll().subscribe({
        next: (data: ActionViewDto[] | null) => {
          this.action = data;
          console.log(this.action);
        },
        error: () => {
          alert("Loading action failed. Please try again later.");
        }
      })
    }
}
