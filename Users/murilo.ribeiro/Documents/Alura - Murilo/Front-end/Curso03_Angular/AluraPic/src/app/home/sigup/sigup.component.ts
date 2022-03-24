import { Router } from '@angular/router';
import { SigUpService } from './sigup.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { lowerCaseValidator } from 'src/app/shared/components/validators/lower-case.validator';
import { UserNotTakenValidationService } from './user-not-taken.validation.service';
import { NewUser } from './new-user';

@Component({
  templateUrl: './sigup.component.html',
  styleUrls: ['./sigup.component.scss'],
})
export class SigUpComponent implements OnInit {
  sigupForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userNotTaken: UserNotTakenValidationService,
    private sigupService: SigUpService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.sigupForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      fullName: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(40),
        ],
      ],
      userName: [
        '',
        [
          Validators.required,
          lowerCaseValidator,
          Validators.minLength(2),
          Validators.maxLength(30),
        ],
        [this.userNotTaken.checkUserNameTaken()],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(14),
        ],
      ],
    });
  }

  sigup() {
    const newUser = this.sigupForm.getRawValue() as NewUser;
    this.sigupService.sigup(newUser).subscribe(
      () => this.router.navigateByUrl(''),
      (err) => console.log(err)
    );
  }
}
