import {
  Component,
  OnInit,
  OnDestroy,
  Output,
  EventEmitter,
} from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit, OnDestroy {
  @Output() onTyping: EventEmitter<string> = new EventEmitter<string>();

  debounce: Subject<string> = new Subject<string>();
  constructor() {}

  ngOnInit(): void {
    this.debounce
      .pipe(debounceTime(300))
      .subscribe((filter) => this.onTyping.emit(filter));
  }

  //Quando o component e destruido, (fechado).
  ngOnDestroy(): void {
    //Para n ocupar o espaço na memória
    this.debounce.unsubscribe();
  }
}
