import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
  training = [
    { id: 1, name: '.Net', description: '.Net description', endDate: '12/2/2023', progress: 60 },
    { id: 2, name: 'Angular', description: 'Angular desc', endDate: '23/05/2023', progress: 80 },
    { id: 3, name: 'C#', description: 'C# is cool', endDate: '09/09/2023', progress: 90 },
    { id: 4, name: '.Net advanced', description: '.Net advanced training is here.', endDate: '07/09/2023', progress: 40 },
    { id: 5, name: 'J++', description: 'J++ I don\'t know what it is.', endDate: '13/10/2023', progress: 20 }
  ]
  constructor() { }
  getAll() {
    return this.training;
  }
}
