import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navbar-admin.component.html',
  styleUrls: ['./navbar-admin.component.css']
})
export class NavbarAdminComponent {
  constructor(
    private router: Router) { }

  navigateToLobby() {
    this.router.navigate([''])
  }

  navigateToSignin() {
    this.router.navigate(['/signin'])
  }
}
