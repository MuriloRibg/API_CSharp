import { LoginGuard } from './../core/auth/login.guard';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { HomeComponent } from './home.component';
import { SigninComponent } from './signin/signin.component';
import { SigUpComponent } from './sigup/sigup.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [LoginGuard],
    children: [
      {
        path: '',
        component: SigninComponent,
        canActivate: [LoginGuard],
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
