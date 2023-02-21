import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminGuard } from 'src/utilities/guards/admin.guard';
import { ManagerGuard } from 'src/utilities/guards/manager.guard';
import { UserGuard } from 'src/utilities/guards/user.guard';
import { NotfoundComponent } from './shared/notfound/notfound.component';

const routes: Routes = [
  {
    path: 'user',
    canActivate: [UserGuard],
    loadChildren: () => import('./user/user.module').then((m) => m.UserModule),
  },
  {
    path: 'manager',
    canActivate: [ManagerGuard],
    loadChildren: () =>
      import('./manager/manager.module').then((m) => m.ManagerModule),
  },
  {
    path: 'admin',
    canActivate: [AdminGuard],
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: '', 
    loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule)
  },
  {
    path: '**',
    component: NotfoundComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
