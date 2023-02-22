import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Email } from '../models/email.model';

@Injectable({
  providedIn: 'root',
})

export class EmailServices {
  constructor(private http: HttpClient) {}
  sentEmail(emailRequest: Email): Observable<Email> {
    return this.http.post<Email>(
      'https://localhost:7264/api/Email',
      emailRequest
    );
  }
}
