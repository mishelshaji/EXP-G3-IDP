import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserRoutingModule } from './user-routing.module';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CurrentProgressComponent } from './shared/current-progress/current-progress.component';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { NgChartsModule } from 'ng2-charts';
import { CurrentObjectivesComponent } from "./shared/current-objectives/current-objectives.component";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { ShowAllIdpComponent } from './show-all-idp/show-all-idp.component';

@NgModule({
    declarations: [
        UserLayoutComponent,
        HomepageComponent,
        CurrentProgressComponent,
        ShowAllIdpComponent,
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        NgCircleProgressModule,
        NgChartsModule,
        CurrentObjectivesComponent,
        CurrentObjectivesComponent,
        FontAwesomeModule,
        FormsModule,
        NgbModule
    ]
})
export class UserModule { }
