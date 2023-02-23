import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmailServices } from 'src/app/service/email.service';
import { Router } from '@angular/router';
import { Email } from 'src/app/models/email.model';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule, NgbModule, FormsModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  model: Email = {
    fromAddress: '',
    subject: '',
    body: '',
  };

  isSubmitting = false;
  isSuccess = false;

  constructor(private emailservice: EmailServices, private router: Router) {}

  sentEmail() {
    this.emailservice.sentEmail(this.model).subscribe({
      next: () => {
        this.isSuccess = true;
        alert('Email is sent successfully');
        this.router.navigate(['/contact']);
      },
      error: () => {
        alert('Sending Message failed\n\t Please check your Email address');
      },
    });
  }

  onSubmit() {
    this.sentEmail();
    this.isSubmitting = true;
    setTimeout(() => {
      this.isSubmitting = false;
      if (!this.isSuccess) {
        this.model.fromAddress = '';
        return;
      }
      this.model.subject = '';
      this.model.fromAddress = '';
      this.model.body = '';
      setTimeout(() => {
        this.isSuccess = false;
      }, 2000);
    }, 5000);
  }
  contactUs() {
    var contactId: any = document.getElementById('contact');
    contactId.style.display = contactId.style.display == 'block' ? 'none' : 'block';
  }
}
