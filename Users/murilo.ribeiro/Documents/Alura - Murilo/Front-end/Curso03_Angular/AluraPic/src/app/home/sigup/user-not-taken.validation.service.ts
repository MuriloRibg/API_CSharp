import { debounceTime, first, map, switchMap } from 'rxjs/operators';
import { AbstractControl } from '@angular/forms';
import { SigUpService } from './sigup.service';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UserNotTakenValidationService {
  constructor(private sinUpService: SigUpService) {}

  checkUserNameTaken() {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        debounceTime(300),
        switchMap((userName) => {
          return this.sinUpService.checkUserNameTaken(userName);
        }),
        map((isTaken) => (isTaken ? { userNameTaken: true } : null)),
        first()
      );
    };
  }
}
