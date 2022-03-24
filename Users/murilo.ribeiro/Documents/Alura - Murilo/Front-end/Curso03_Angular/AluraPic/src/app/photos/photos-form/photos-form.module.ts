import { RouterModule } from '@angular/router';
import { VmessageModule } from './../../shared/components/vmessage/vmessage.module';
import { CommonModule } from '@angular/common';
import { PhotosFormComponent } from './photos-form.component';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PhotosFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    VmessageModule,
    FormsModule,
    RouterModule
  ],
})
export class PhotosFormModule {}
