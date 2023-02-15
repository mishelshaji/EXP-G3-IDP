import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent {
  display = 'none';
  model = {
    email: '',
    password: '',
    otp: ''
  }

  clicked(e: any) {
    this.display = 'block';
  }
}
