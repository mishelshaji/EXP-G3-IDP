import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingLayoutComponent } from './landing-layout/landing-layout.component';
import { LobbyComponent } from './lobby/lobby.component';
import { SigninComponent } from '../landing/signin/signin.component';
import { ForgotComponent } from '../user/forgot/forgot.component';
import { UserUploadComponent } from '../admin/user-upload/user-upload.component';

const routes: Routes = [
  {
    path: '', component: LandingLayoutComponent, children: [
      { path: '', component: LobbyComponent },
      { path: 'signin', component: SigninComponent },
      { path: 'forgot-password', component: ForgotComponent },
      { path: 'userupload', component: UserUploadComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LandingRoutingModule { }
