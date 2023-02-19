import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarUserComponent } from '../navbar-user/navbar-user.component';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-notfound',
  standalone: true,
  imports: [CommonModule, NavbarComponent],
  templateUrl: './notfound.component.html',
  styleUrls: ['./notfound.component.css'],
})
export class NotfoundComponent {}
