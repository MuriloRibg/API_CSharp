import { CommonModule } from '@angular/common';
import { DarkenOnHoverDirectives } from './darken-on-hover.directives';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [DarkenOnHoverDirectives],
  imports: [CommonModule],
  exports: [DarkenOnHoverDirectives]
})
export class DarkenOnHoverModule {}
