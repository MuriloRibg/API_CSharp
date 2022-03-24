import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { HomeComponent } from './home.component';
import { AuthGuard } from '../core/auth/auth.guard';
import { SigninComponent } from './signin/signin.component';
import { SigUpComponent } from './sigup/sigup.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: SigninComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'sigup',
        component: SigUpComponent,
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
