import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { jwtDecode } from 'jwt-decode';
import { TranslocoService } from '@ngneat/transloco';

@Component({
  selector: 'app-login',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit {
  constructor(private readonly translocoService: TranslocoService) {
    this.translocoService.translate('register.title');
    this.translocoService.translate('register.description');
    this.translocoService.translate('register.name');
    this.translocoService.translate('register.age');
    this.translocoService.translate('register.email');
    this.translocoService.translate('register.password');
    this.translocoService.translate('register.confirmPassword');
    this.translocoService.translate('register.button');
    this.translocoService.translate('register.footer_title');
    this.translocoService.translate('register.register');
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
  register() {
    this.authService.register(this.form.value).subscribe({
      next: (response) => {
        console.log(response);

        // this.decodedToken = jwtDecode(localStorage.getItem(this.tokenKey)!);
        // for (let index = 0; index < this.decodedToken.role.length; index++) {
        // localStorage.setItem('role', this.decodedToken.role);
        this.router.navigate(['/login']);
        // }

        this.matSnackBar.open(response.message, 'Close', {
          duration: 5000,
          horizontalPosition: 'center',
        });

        // localStorage.setItem('isLogin', 'true');
      },
      error: (err) => {
        console.log(err.error[0]);

        this.matSnackBar.open(err.error[0].description, 'Close', {
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
      fullName: ['', Validators.required],
      age: ['', Validators.required],
      // username: ['', ],
    });
  }
}
