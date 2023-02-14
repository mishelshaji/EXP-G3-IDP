import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent {
  unset = 'set';
  model = {
    email: '',
    password: '',
    otp: ''
  }

  clicked(e: any) {
    this.unset = 'unset';
  }
}
