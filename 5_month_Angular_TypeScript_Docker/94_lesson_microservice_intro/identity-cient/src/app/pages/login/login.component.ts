import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { jwtDecode } from 'jwt-decode';
import { TranslocoService } from '@ngneat/transloco';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  constructor(private readonly translocoService: TranslocoService) {
    this.translocoService.translate('title');
    this.translocoService.translate('form.description');
    this.translocoService.translate('form.email');
    this.translocoService.translate('form.password');
    this.translocoService.translate('form.button');
    this.translocoService.translate('form.footer_title');
    this.translocoService.translate('form.register');

    var language = localStorage.getItem('lang');
    localStorage.clear();
    localStorage.setItem('lang', language!);
  }

  matSnackBar = inject(MatSnackBar);
  router = inject(Router);
  hide = true;
  form!: FormGroup;
  fb = inject(FormBuilder);
  authService = inject(AuthService);
  decodedToken: any | null;
  tokenKey = 'token';
  roles: string[] = [];
  tokenDecoded: any;

  login() {
    this.authService.login(this.form.value).subscribe({
      next: (response) => {
        this.decodedToken = jwtDecode(localStorage.getItem(this.tokenKey)!);
        // if()
        for (let index = 0; index < this.decodedToken.role.length; index++) {
          localStorage.setItem('role', this.decodedToken.role);
          localStorage.setItem('userName', this.decodedToken.name);
          // if (this.decodedToken.role == 'Admin') {
          // this.router.navigate(['/home']);
          // } else if (this.decodedToken.role == 'Student') {
          this.router.navigate(['/home']);
          this.router.navigateByUrl('/home');
          // }
        }

        this.matSnackBar.open(response.message, 'Close', {
          duration: 5000,
          horizontalPosition: 'center',
        });

        this.tokenDecoded = jwtDecode(localStorage.getItem(this.tokenKey)!);
        // console.log('decoded token');
        // console.log(this.tokenDecoded);
        // console.log('data kelyabdi');
        // console.log(Date.now());

        localStorage.setItem('isLogin', 'true');
      },
      error: (err) => {
        console.log(err);

        this.matSnackBar.open(err.error, 'Close', {
          duration: 5000,
          horizontalPosition: 'center',
        });
      },
    });
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }
}
