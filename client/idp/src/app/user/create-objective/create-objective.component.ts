import { Component } from '@angular/core';

@Component({
  selector: 'app-create-objective',
  templateUrl: './create-objective.component.html',
  styleUrls: ['./create-objective.component.css']
})
export class CreateObjectiveComponent {
  model = {
    name: '',
    description: '',
    category: '',
    start: '',
    end: ''
  };

  onSubmit(val: any) {
    console.log(val);
  }

}
