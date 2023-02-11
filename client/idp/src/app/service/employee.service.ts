import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  training = [
    { id: 1, name: 'Elon Musk', age: 10, Department: 'Above all', designation: 'CEO', mobile: 5557778888, email: 'elonmusk@gmail.com' },
  ]
  
  constructor() { }
  getAll() {
    return this.training;
  }
}
