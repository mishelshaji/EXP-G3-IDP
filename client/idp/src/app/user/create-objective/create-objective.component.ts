import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/service/category.service';
import { ObjectiveService } from 'src/app/service/objective.service';

@Component({
  selector: 'app-create-objective',
  templateUrl: './create-objective.component.html',
  styleUrls: ['./create-objective.component.css']
})
export class CreateObjectiveComponent {
  model = {
    idpId: 0,
    name: '',
    categoryId: 0,
    status: 1,
    startDate: new Date(),
    endDate: new Date()
  };

  currentDate = new Date().toISOString().split('T')[0];
  
  category: CategoryViewDto[] | null = null;

  objectives: ObjectiveViewDto[] | null = null;

  constructor(
    private objectiveService: ObjectiveService,
    private categoryService: CategoryService,
    private router: ActivatedRoute,
    private navigate: Router) { }

    ngOnInit() {      
    this.model.idpId = this.router.snapshot.params["id"];
      this.categoryService.getAll().subscribe({
        next: (data: CategoryViewDto[] | null) => {
          this.category = data;
        },
        error: () => {
          console.log("Loading category failed. Please try again later.");
        }
      })
    }

  createObjective() {
    console.log(this.model);
    this.objectiveService.create(this.model).subscribe({
        next: () => {
            alert("Objective created successfully");
            return this.navigate.navigate(['user', 'objectives', this.model.idpId]);
        },
        error: (error) => {
            console.error(error);
            console.log(this.model);
            alert("Error creating objective");
        }
    })
  }
}
