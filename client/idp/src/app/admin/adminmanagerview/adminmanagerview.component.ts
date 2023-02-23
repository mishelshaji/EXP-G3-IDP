import { Component, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeIdpService } from 'src/app/service/employeeIdp.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-adminmanagerview',
  templateUrl: './adminmanagerview.component.html',
  styleUrls: ['./adminmanagerview.component.css'],
})
export class AdminmanagerviewComponent {
  @ViewChild('htmlData') htmlData!: ElementRef;
  
  selectedStatus = 3;

  managerId: string = '';

  constructor(private employeeIdp: EmployeeIdpService, private router: ActivatedRoute) { }

  intervalIds: any[] = [];

  objectivePending: PendingObjectiveDto[] | null = null;

  public openPDF():void{
  let DATA: any = document.getElementById('htmlData');
  html2canvas(DATA).then((canvas) => {
    let fileWidth = 250;
    let fileHeight = (canvas.height * fileWidth) / canvas.width;
    const FILEURI = canvas.toDataURL('image/png');
    let PDF = new jsPDF('l', 'mm', 'a4');
    let position = 1;
    PDF.addImage(FILEURI, 'PNG', 0, position, fileWidth, fileHeight);
    PDF.save('IDP-Report.pdf');
  });
  }

ngOnInit() {
  this.managerId = this.router.snapshot.params["id"];
  this.employeeIdp.getPending(this.managerId).subscribe({
    next: (data) => {
      this.objectivePending = data;
      console.log(this.objectivePending);
    },
    error: (error) => {
      console.log(error);
      console.log("Loading idp failed. Please try again later.");
    }
  });
}
}
