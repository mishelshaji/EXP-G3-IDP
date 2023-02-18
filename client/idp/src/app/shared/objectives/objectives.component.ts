import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-objectives',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './objectives.component.html',
  styleUrls: ['./objectives.component.css']
})
export class ObjectivesComponent {
  list: number[] = [1, 2, 3, 4, 5, 6, 7, 8]
}
