import { Component, ViewChild, ElementRef } from '@angular/core';
import { faPlusSquare } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  @ViewChild('year') year:string;

  currentYear:number = new Date().getFullYear();
  employeeId:number = 21010;
  arrowRightIcon = faPlusSquare;
  
  idpName:string = ``;
  
  ngAfterViewInit() {
    this.year = `2023`;
  }
  
  constructor() {
    this.year = `2023`;
  }
  
  model = {
    name: '',
    year: ''
  };
}
