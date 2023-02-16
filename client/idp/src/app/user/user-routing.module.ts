import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddActionComponent } from './add-action/add-action.component';
import { AddTrainingComponent } from './add-training/add-training.component';
import { ForgotComponent } from './forgot/forgot.component';
import { HomepageComponent } from './homepage/homepage.component';
import { SigninComponent } from './signin/signin.component';
import { ObjectiveDetailedComponent } from '../shared/objective-detailed/objective-detailed.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';

const routes: Routes = [
  {
    path: '', component: UserLayoutComponent, children: [
      { path: '', component: HomepageComponent },
      { path: 'signin', component: SigninComponent },
      { path: 'forgot-password', component: ForgotComponent },
      { path: 'add-training', component: AddTrainingComponent },
      { path: 'add-action', component: AddActionComponent}
      { path: 'home', component: HomepageComponent },
      { path: 'objective-detailed', component: ObjectiveDetailedComponent },
      { path: 'idp', component: ShowAllIdpComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
