import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ObjectiveDetailedComponent } from '../shared/objective-detailed/objective-detailed.component';
import { ObjectivesComponent } from '../shared/objectives/objectives.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ProfileComponent } from './profile/profile.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';

const routes: Routes = [
  {
    path: '', component: UserLayoutComponent, children: [
      { path: '', component: HomepageComponent },
      { path: 'objective-detailed', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'objectives', component: ObjectivesComponent },
      { path: 'profile', component: ProfileComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
