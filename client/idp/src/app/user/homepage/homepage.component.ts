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
  
  userId = {
    id: ''
  }

  model: IdpCreateDto = {
    name: '',
    year: new Date(),
    userId: this.userId.id
  }

  changeFunction(e:any) {
    this.model.userId = this.userId.id;
    this.model.name = 'IDP ' + 799 + ' ' + e;   
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
        this.userId = data;
        console.log(this.userId.id);
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
