import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRoutingModule } from './landing-routing.module';
import { LobbyComponent } from './lobby/lobby.component';
import { LandingLayoutComponent } from './landing-layout/landing-layout.component';
import { NavbarComponent } from '../shared/navbar/navbar.component';

@NgModule({
  declarations: [
    LobbyComponent,
    LandingLayoutComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    NavbarComponent
  ]
})
export class LandingModule { }
