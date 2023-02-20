import { Component, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IdpService } from 'src/app/service/idp.service';
import { ProfileService } from 'src/app/service/profile.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent {
  
  employee = {
    employeeId: 0
  }

  model: IdpCreateDto = {
    name: '',
    year: 0,
  }

  changeFunction(e:any) {
    this.model.name = 'IDP ' + this.employee.employeeId + ' ' + e;   
    this.model.year = e;
  }


  idps: IdpViewDto[] | null = null;

  constructor(
    private idpService: IdpService,
    private profileService: ProfileService,
    private router: Router) { }

  ngOnInit(): void {
    this.profileService.get().subscribe({
      next: (data) => {
        this.employee = data;
        console.log(this.employee.employeeId);
      },
      error: () => {
        console.log("Loading id failed. Please try again later.");        
      }
    })
  }

  createIdp() {
    this.idpService.create(this.model).subscribe({
        next: () => {
            alert("Idp created successfully");
            return this.router.navigate(['user', 'idp']);
        },
        error: (error) => {
            console.error(error);
            console.log(this.model);
            
            alert("Error creating idp");
        }
    })
  }

}
