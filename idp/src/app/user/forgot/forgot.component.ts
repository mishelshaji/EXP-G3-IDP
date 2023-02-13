import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.css']
})
export class ForgotComponent {
  model = {
    email: '',
    password: '',
    otp: ''
  }

  clicked(e: any) {
    var target = e.target as HTMLDocument;
    console.log(target);
    var t1: any = document.getElementById('otpfield')
    var t2: any = document.getElementById('subfield')
    t1.style.display = 'unset';
    t2.style.display = 'unset';
  }
}
