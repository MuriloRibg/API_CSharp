import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[app-darkenOnHover]',
})
export class DarkenOnHoverDirectives {
  constructor(private el: ElementRef, private render: Renderer2) {}

  @HostListener('mouseover')
  public darkenOn() {
    this.render.setStyle(this.el.nativeElement,'filter', 'brightness(80%)');
  }

  @HostListener('mouseleave')
  public darkenOff() {
    this.render.setStyle(this.el.nativeElement,'filter', 'brightness(100%)');
  }
}
