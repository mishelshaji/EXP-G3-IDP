import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddActionComponent } from './add-action/add-action.component';
import { AddTrainingComponent } from './add-training/add-training.component';
import { ObjectivesComponent } from '../shared/objectives/objectives.component';
import { ProfileComponent } from './profile/profile.component';
import { CreateObjectiveComponent } from './create-objective/create-objective.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ObjectiveDetailedComponent } from '../shared/objective-detailed/objective-detailed.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { UserUploadComponent } from './user-upload/user-upload.component';

const routes: Routes = [
  {
    path: '', component: UserLayoutComponent, children: [
      { path: '', component: HomepageComponent },
      { path: 'objective-detailed/:id', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'objectives/:id', component: ObjectivesComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'add-training/:id', component: AddTrainingComponent },
      { path: 'add-action/:id', component: AddActionComponent},
      { path: 'home', component: HomepageComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'create-objective/:id', component: CreateObjectiveComponent },
      { path: 'userupload', component: UserUploadComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
