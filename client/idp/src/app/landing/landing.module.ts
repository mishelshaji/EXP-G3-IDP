import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingRoutingModule } from './landing-routing.module';
import { LobbyComponent } from './lobby/lobby.component';
import { LandingLayoutComponent } from './landing-layout/landing-layout.component';
import { NavbarComponent } from '../shared/navbar/navbar.component';
import { FooterComponent } from '../shared/footer/footer.component';

@NgModule({
  declarations: [
    LobbyComponent,
    LandingLayoutComponent
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    NavbarComponent,
    FooterComponent
  ]
})
export class LandingModule { }
