import { NgModule } from '@angular/core';

import { PhotosListModule } from './photos-list/photos-list.module';
import { PhotosFormModule } from './photos-form/photos-form.module';
import { PhotoModule } from './photo/photo.module';
import { DarkenOnHoverModule } from '../shared/directives/darken-on-hover/darken-on-hover.module';

@NgModule({
  imports: [
    PhotoModule,
    PhotosFormModule,
    PhotosListModule,
    DarkenOnHoverModule,
  ],
})
export class PhotosModule {}
