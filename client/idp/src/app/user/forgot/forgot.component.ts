import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent {
  display: boolean = false;
  model = {
    email: '',
    password: '',
    otp: ''
  }

  clicked(e: any) {
    this.display = true;
  }
}
