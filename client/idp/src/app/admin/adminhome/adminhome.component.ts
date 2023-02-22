import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ManagerProfileService } from 'src/app/service/managerProfile.service';

interface Manager {
  slNo: number;
  profilePictureUrl: string; // new property for profile picture URL
  employeeId: number;
  name: string;
  designation: string;
  idpName: string;
  objective: string;
  training: string;
  actionItem: string;
}

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.css']
})
export class AdminhomeComponent {

  managers: ProfileViewDto[] | null = null;

    constructor(private router: Router, private profileService: ManagerProfileService) {}

    ngOnInit(): void {
      this.profileService.getManager().subscribe({
        next: (data) => {
          this.managers = data;
          console.log(this.managers);
        },
        error: () => {
          console.log("Loading id failed. Please try again later.");        
        }
      });
    }
    
    viewManager(manager: Manager) {
      console.log(manager);
    }
  }

