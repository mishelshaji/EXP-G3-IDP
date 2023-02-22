import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IdpService } from 'src/app/service/idp.service';

@Component({
  selector: 'app-show-all-idp',
  templateUrl: './show-all-idp.component.html',
  styleUrls: ['./show-all-idp.component.css']
})
export class ShowAllIdpComponent {
    /**
   * This is the list of idp that will be displayed in the UI.
   * It will be initialized in the ngOnInit method. The default value is null.
   */
    idp: IdpViewDto[] | null = null;


    /**
     * @param service This is the instance of idpService that will be used to
     */
    constructor(private service: IdpService) {
  
    }
  
    /**
     * This method will be called when the component is initialized. It will
     * fetch the list of idp from the server. The list will be stored
     * in the idp property. If the server returns an error, an alert
     * will be displayed to the user.
     */
    ngOnInit() {
      this.service.getAll().subscribe({
        next: (data: IdpViewDto[] | null) => {
          this.idp = data;
          console.log(this.idp);
        },
        error: () => {
          alert("Loading idp failed. Please try again later.");
        }
      })
    }
}
