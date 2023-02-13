import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  contactUs() {
    var contactId: any = document.getElementById('contact');
    contactId.style.display = contactId.style.display == 'block' ? 'none' : 'block';
  }
}
