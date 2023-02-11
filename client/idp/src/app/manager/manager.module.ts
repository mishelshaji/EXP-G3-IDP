import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerRoutingModule } from './manager-routing.module';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';
import { HomeComponent } from './home/home.component';
import { ViewAllEmployeeComponent } from '../shared/view-all-employee/view-all-employee.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ManagerLayoutComponent,
    HomeComponent
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
