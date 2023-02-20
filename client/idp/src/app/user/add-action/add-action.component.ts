import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActionService } from 'src/app/service/action.service';

@Component({
  selector: 'app-add-action',
  templateUrl: './add-action.component.html',
  styleUrls: ['./add-action.component.css']
})
export class AddActionComponent {
  model = {
    objectiveId: 0,
    description: '',
    progress: 0,
    name: '',
    startDate: new Date(),
    endDate: new Date(),
    certificate: '',
  }

  constructor(
    private service: ActionService,
    private router: ActivatedRoute) { }

  formData = new FormData();

  ngOnInit() {
    this.model.objectiveId = this.router.snapshot.params["id"];
  }

  createAction() {
    this.formData.append("name", this.model.name);
    this.formData.append("description", this.model.description);
    this.formData.append("startDate", this.model.startDate.toString());
    this.formData.append("endDate", this.model.endDate.toString());
    this.formData.append("progress", this.model.progress.toString());
    this.formData.append("objectiveId", this.model.objectiveId.toString());

    console.log(this.formData);
    this.service.create(this.formData).subscribe({
      next: () => {
        alert("Action created successfully");
      },
      error: (error) => {
        console.error(error);
        alert("Error creating action");
      }
    })
  }
  
  fileSelected(e: any) {
    const file: File = e.target.files[0];
    if (file) {
      this.formData.append("certificate", file, file.name);
    }
  }
}
