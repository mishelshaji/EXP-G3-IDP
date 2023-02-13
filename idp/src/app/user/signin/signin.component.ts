import { Component } from '@angular/core';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  model = {
    email: '',
    password: ''
  }
  OnSubmit(form: any) {
    console.log(form);
  }
  showData(email: any) {
    console.log(email);
  }
}
