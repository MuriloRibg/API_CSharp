import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/auth/auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
  loginForm!: FormGroup;
  @ViewChild('userName') userNameInput!: ElementRef<HTMLInputElement>;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required], //valor inicial, validação
      password: ['', Validators.required],
    });
    this.userNameInput.nativeElement.focus()
  }

  login(): void {
    const userName = this.loginForm.get('userName')?.value;
    const password = this.loginForm.get('password')?.value;

    this.authService.authenticate(userName, password).subscribe(
      () => this.router.navigate(['user', userName]),
      (err) => {
        console.log(err);
        this.userNameInput.nativeElement.focus();
        this.loginForm.reset();
      }
    );
  }
}
