import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ObjectiveService } from 'src/app/service/objective.service';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-objectives',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './objectives.component.html',
  styleUrls: ['./objectives.component.css']
})
export class ObjectivesComponent {
  /**
 * This is the list of objective that will be displayed in the UI.
 * It will be initialized in the ngOnInit method. The default value is null.
 */
  objective: ObjectiveViewDto[] | null = null;

  objectiveLength: number = 0;

  idpId = 0;

  role: any;

  /**
   * @param service This is the instance of objectiveService that will be used to
   */
  constructor(private service: ObjectiveService, private router: ActivatedRoute, private token: TokenHelper) {

  }

  /**
   * This method will be called when the component is initialized. It will
   * fetch the list of objective from the server. The list will be stored
   * in the objective property. If the server returns an error, an alert
   * will be displayed to the user.
   */
  ngOnInit() {
    this.role = this.token.getDecodedToken().userrole;
    this.idpId = this.router.snapshot.params["id"];
    this.service.getAll(this.idpId).subscribe({
      next: (data: ObjectiveViewDto[]) => {
        this.objective = data;
        this.objectiveLength = data?.length;
        console.log(data?.length);
      },
      error: () => {
        alert("Loading objective failed. Please try again later.");
      }
    })
  }
}
