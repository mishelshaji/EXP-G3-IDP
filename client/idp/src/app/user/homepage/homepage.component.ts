import { Component, ViewChild, ElementRef } from '@angular/core';
import { faPlusSquare } from '@fortawesome/free-regular-svg-icons';
import { IdpService } from 'src/app/service/idp.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  @ViewChild('year') year: number = 2023;

  idpFetchYear: number[] = [];
  selectedIdp: number = new Date().getFullYear();
  currentYear: number = new Date().getFullYear();
  employeeId: number = 21010;
  arrowRightIcon = faPlusSquare;
  idpName: string = ``;
  idpItem: any[] = [];

  ngAfterViewInit() {
    this.year = 2023;
  }

  constructor(private idpService: IdpService) {

  }

  ngOnInit() {
    this.idpItem = this.idpService.getAll();
    this.idpItem.forEach(element => {
      this.idpFetchYear.push(element.year);
    });
  }

  setIdp(item: number) {
    this.selectedIdp = item;
  }

  model = {
    name: '',
    year: ''
  };
}
