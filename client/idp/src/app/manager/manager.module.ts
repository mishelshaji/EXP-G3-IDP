import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManagerRoutingModule } from './manager-routing.module';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';
import { ViewAllEmployeeComponent } from '../shared/view-all-employee/view-all-employee.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { HomepageComponent } from './homepage/homepage.component';
import { UserRoutingModule } from '../user/user-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { NavbarManagerComponent } from '../shared/navbar-manager/navbar-manager.component';

@NgModule({
  declarations: [
    ManagerLayoutComponent,
    HomepageComponent,
    ShowAllIdpComponent,
  ],
  imports: [
    CommonModule,
    ManagerRoutingModule,
    ViewAllEmployeeComponent,
    FontAwesomeModule,
    FormsModule,
    UserRoutingModule,
    NgbModule,
    NavbarManagerComponent,
    RouterModule,
    FooterComponent
  ]
})
export class ManagerModule { }
