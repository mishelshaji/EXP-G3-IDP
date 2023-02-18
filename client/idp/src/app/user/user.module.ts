import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserRoutingModule } from './user-routing.module';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CurrentProgressComponent } from './shared/current-progress/current-progress.component';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { NgChartsModule } from 'ng2-charts';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SigninComponent } from './signin/signin.component';
import { FormsModule } from '@angular/forms';
import { ForgotComponent } from './forgot/forgot.component';
import { AddTrainingComponent } from './add-training/add-training.component';
import { AddActionComponent } from './add-action/add-action.component';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';
import { ShowAllObjectiveComponent } from './show-all-objective/show-all-objective.component';
import { ObjectivesComponent } from '../shared/objectives/objectives.component';
import { NavbarUserComponent } from '../shared/navbar-user/navbar-user.component';
import { ProfileComponent } from './profile/profile.component';
import { CreateObjectiveComponent } from './create-objective/create-objective.component';
import { UserUploadComponent } from './user-upload/user-upload.component';

@NgModule({
    declarations: [
        UserLayoutComponent,
        HomepageComponent,
        CurrentProgressComponent,
        SigninComponent,
        ForgotComponent,
        AddTrainingComponent,
        AddActionComponent,
        ShowAllIdpComponent,
        ShowAllObjectiveComponent,
        ProfileComponent,
        CreateObjectiveComponent,
        UserUploadComponent,
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        NgCircleProgressModule,
        NgChartsModule,
        FontAwesomeModule,
        FormsModule,
        NgbModule,
        ObjectivesComponent,
        NavbarUserComponent,
    ]
})
export class UserModule { }
