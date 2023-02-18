import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/service/employee.service';

@Component({
  selector: 'app-user-upload',
  templateUrl: './user-upload.component.html',
  styleUrls: ['./user-upload.component.css']
})
export class UserUploadComponent {

  formData = new FormData();

  constructor(private employee: EmployeeService){}

  fileSelected(e: any) {
    const file: File = e.target.files[0];
    if (file) {
      this.formData.append("image", file, file.name);
    }
  }

  uploadFile(){
    this.employee.create(this.formData).subscribe({
      next: () => {
        alert("Employees added successfully");
    },
    })
  }
}
