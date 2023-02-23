import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-navbar-admin',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar-admin.component.html',
  styleUrls: ['./navbar-admin.component.css']
})

export class NavbarAdminComponent {
  constructor(private router: Router, private token: TokenHelper) {
    
  }

  logout() {
    this.token.removeToken();
    this.router.navigate(['/signin'])
  }
}
