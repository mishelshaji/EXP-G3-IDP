import { Component } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  model = {
    training: ''
  }
  onSubmit(form: any) {
    console.log(form.valid);
  }
}
