import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TrainingService {
  url = 'https://localhost:7264/api/admin/trainings';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<TrainingViewDto[]>(this.url);
  }
}
