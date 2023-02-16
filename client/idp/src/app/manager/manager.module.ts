import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerRoutingModule } from './manager-routing.module';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';
import { ViewAllEmployeeComponent } from '../shared/view-all-employee/view-all-employee.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { HomepageComponent } from './homepage/homepage.component';

@NgModule({
  declarations: [
    ManagerLayoutComponent,
    HomepageComponent
  ],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    ViewAllEmployeeComponent,
    FontAwesomeModule,
    FormsModule
  ]
})
export class ManagerModule { }
