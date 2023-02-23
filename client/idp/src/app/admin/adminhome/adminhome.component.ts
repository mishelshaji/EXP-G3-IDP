import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/service/category.service';
import { EmployeeService } from 'src/app/service/employee.service';
import { ManagerProfileService } from 'src/app/service/managerProfile.service';

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.css']
})
export class AdminhomeComponent {

  managers: ProfileViewDto[] | null = null;

  model: CategoryCreateDto = {
    name: ''
  }

  formData = new FormData();

  constructor(private router: Router, private profileService: ManagerProfileService,
    private category: CategoryService, private employee: EmployeeService) { }


  fileSelected(e: any) {
    const file: File = e.target.files[0];
    if (file) {
      this.formData.append("file", file, file.name);
    }
  }

  setCategory() {
    this.category.create(this.model).subscribe({
      next: () => {
        alert("Catetegory added successfully");
      },
    })
  }

  uploadFile() {
    this.employee.create(this.formData).subscribe({
      next: () => {
        alert("Employees added successfully");
      },
    })
  }

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
}

