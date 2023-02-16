import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IdpService {
  idp = [
    { id: 1, name: '.Net expert', year: '2019' },
    { id: 2, name: 'Expert in Angular', year: '2020' },
    { id: 3, name: '.Net advanced', year: '2021' },
    { id: 4, name: 'node expert', year: '2022' },
    { id: 5, name: 'become good at preesentation', year: '2023' },

  ]

  constructor() { }
    
  getAll() {
    return this.idp;
  }
}
