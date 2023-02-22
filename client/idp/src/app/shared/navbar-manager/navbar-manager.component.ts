import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

@Component({
  selector: 'app-navbar-manager',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './navbar-manager.component.html',
  styleUrls: ['./navbar-manager.component.css']
})

export class NavbarManagerComponent {
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
    this.router.navigate(['/signin'])
  }
}
