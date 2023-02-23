import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';

const routes: Routes = [
  {
    path: '',
    component: ManagerLayoutComponent,
    children: [
      { path: '', component: HomepageComponent },
      { path: 'idp/:id', component: ShowAllIdpComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagerRoutingModule {}
