import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvalidpageComponent } from './shared/invalidpage/invalidpage.component';

const routes: Routes = [
  {
    path: 'user', 
    loadChildren: () => import('./user/user.module').then(m => m.UserModule)
  },
  {
    path: 'manager', 
    loadChildren: () => import('./manager/manager.module').then(m => m.ManagerModule)
  },
  {
    path: 'admin', 
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'invalid', component: InvalidpageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
