import { Component } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  userRole: string = "Please select a role.";

  setRole(role: string) {
    this.userRole = role;
  }
}
