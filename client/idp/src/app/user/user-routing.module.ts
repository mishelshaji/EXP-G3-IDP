import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddActionComponent } from './add-action/add-action.component';
import { AddTrainingComponent } from './add-training/add-training.component';
import { ForgotComponent } from './forgot/forgot.component';
import { ObjectivesComponent } from '../shared/objectives/objectives.component';
import { ProfileComponent } from './profile/profile.component';
import { CreateObjectiveComponent } from './create-objective/create-objective.component';
import { HomepageComponent } from './homepage/homepage.component';
import { SigninComponent } from './signin/signin.component';
import { ObjectiveDetailedComponent } from '../shared/objective-detailed/objective-detailed.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { UserUploadComponent } from './user-upload/user-upload.component';

const routes: Routes = [
  {
    path: '', component: UserLayoutComponent, children: [
      { path: '', component: HomepageComponent },
      { path: 'objective-detailed', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'objectives', component: ObjectivesComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'signin', component: SigninComponent },
      { path: 'forgot-password', component: ForgotComponent },
      { path: 'add-training', component: AddTrainingComponent },
      { path: 'add-action', component: AddActionComponent},
      { path: 'home', component: HomepageComponent },
      { path: 'objective-detailed', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent },
      { path: 'objective', component: CreateObjectiveComponent },
      { path: 'userupload', component: UserUploadComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
