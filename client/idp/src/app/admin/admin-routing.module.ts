import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { AdminmanagerviewComponent } from './adminmanagerview/adminmanagerview.component';
import { GetReportComponent } from './get-report/get-report.component';
import { UserUploadComponent } from './user-upload/user-upload.component';

const routes: Routes = [
  {
    path: '', component: AdminLayoutComponent, children: [
      { path: '', component:  AdminhomeComponent},
      { path: 'report', component:  GetReportComponent},
      { path: 'register', component:  UserUploadComponent},
      { path: 'view/:id', component:  AdminmanagerviewComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
