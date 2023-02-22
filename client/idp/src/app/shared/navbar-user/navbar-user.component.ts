import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-navbar-user',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar-user.component.html',
  styleUrls: ['./navbar-user.component.css']
})

export class NavbarUserComponent {
  createIdp() {
    var id: any = document.getElementById('idp');
    id.style.display = id.style.display == 'block' ? 'none' : 'block';
  }

  /**
   *
   */
  constructor(private router: Router, private token: TokenHelper) {
    
  }

  navigateToProfile() {
    this.router.navigate(['/user/profile'])
  }

  logout() {
    this.token.removeToken();
    window.location.reload();
  }
}
