import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-objective-detailed',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './objective-detailed.component.html',
  styleUrls: ['./objective-detailed.component.css'],
})
export class ObjectiveDetailedComponent {
  list: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3];
  trainings: TrainingViewDto[] = [];
}
