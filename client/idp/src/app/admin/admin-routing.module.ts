import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { GetReportComponent } from './get-report/get-report.component';
import { HomepageComponent } from './homepage/homepage.component';
import { UserUploadComponent } from './user-upload/user-upload.component';

const routes: Routes = [
  {
    path: '', component: AdminLayoutComponent, children: [
      { path: '', component:  HomepageComponent},
      { path: 'report', component:  GetReportComponent},
      { path: 'register', component:  UserUploadComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
