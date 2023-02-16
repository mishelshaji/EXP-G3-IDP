import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

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
}
