import { Component } from '@angular/core';
import { ProfileService } from 'src/app/service/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  /**
   * This is the profile that will be displayed in the UI.
   * It will be initialized in the ngOnInit method. The default value is null.
   */
  profile:any = {
    firstName: '',
    lastName: '',
    email: '',
    department: '',
    designation: '',
    employeeId: '',
    mobile: '',
    dob: '',
    gender: ''
  }

  /**
   * @param service This is the instance of ProfileService that will be used to
   */
  constructor(private service: ProfileService) {

  }

  /**
   * This method will be called when the component is initialized. It will
   * fetch the profile from the server. The profile will be stored
   * in the profile property. If the server returns an error, an alert
   * will be displayed to the user.
   */
  ngOnInit() {
    this.service.getById(1).subscribe({
      next: (data) => {
        this.profile = data;
        console.log(this.profile);  
      },
      error: () => {
        alert("Loading profile failed. Please try again later.");
      }
    })
  }
}
