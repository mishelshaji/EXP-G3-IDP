import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeIdpService } from 'src/app/service/employeeIdp.service';

@Component({
  selector: 'app-adminmanagerview',
  templateUrl: './adminmanagerview.component.html',
  styleUrls: ['./adminmanagerview.component.css'],
})
export class AdminmanagerviewComponent {
  selectedStatus = 3;

  managerId: string = '';

  constructor(private employeeIdp: EmployeeIdpService, private router: ActivatedRoute) { }

  intervalIds: any[] = [];

  objectivePending: PendingObjectiveDto[] | null = null;

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
