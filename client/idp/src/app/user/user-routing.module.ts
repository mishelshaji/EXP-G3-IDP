import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectiveDetailedComponent } from '../shared/objective-detailed/objective-detailed.component';
import { CreateObjectiveComponent } from './create-objective/create-objective.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';

const routes: Routes = [
  {
    path: '', component: UserLayoutComponent, children: [
      { path: 'home', component: HomepageComponent },
      { path: 'objective-detailed', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'objective', component: CreateObjectiveComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
