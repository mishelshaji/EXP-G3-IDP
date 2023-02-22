import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { RegistrationComponent } from './registration/registration.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GetReportComponent } from './get-report/get-report.component';
import { RouterModule } from '@angular/router';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { AdminmanagerviewComponent } from './adminmanagerview/adminmanagerview.component';
import { NavbarAdminComponent } from '../shared/navbar-admin/navbar-admin.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RegistrationComponent,
    AdminLayoutComponent,
    GetReportComponent,
    AdminhomeComponent,
    AdminmanagerviewComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbModule,
    FontAwesomeModule,
    RouterModule,
    NavbarAdminComponent,
    FormsModule
  ]
})
export class AdminModule { }
