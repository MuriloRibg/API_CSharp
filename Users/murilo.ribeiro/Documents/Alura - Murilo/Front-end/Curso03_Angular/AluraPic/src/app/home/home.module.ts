import { HomeComponent } from './home.component';
import { BrowserModule } from '@angular/platform-browser';
import { SigUpComponent } from './sigup/sigup.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { VmessageModule } from './../shared/components/vmessage/vmessage.module';
import { SigninComponent } from './signin/signin.component';
import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [SigninComponent, SigUpComponent, HomeComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    VmessageModule,
    RouterModule,
    HomeRoutingModule
  ],
  exports: [SigninComponent, SigUpComponent, HomeComponent],
})
export class HomeModule {}
