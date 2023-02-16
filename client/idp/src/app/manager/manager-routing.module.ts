import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ManagerLayoutComponent } from './manager-layout/manager-layout.component';

const routes: Routes = [
  {
    path: '', component: ManagerLayoutComponent, children: [
      { path: 'home', component:  HomeComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManagerRoutingModule { }
