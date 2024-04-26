import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
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
        for (let index = 0; index < this.decodedToken.role.length; index++) {
          localStorage.setItem('role', this.decodedToken.role);
          // if (this.decodedToken.role == 'Admin') {
            // this.router.navigate(['/home']);
          // } else if (this.decodedToken.role == 'Student') {
            this.router.navigate(['/home']);
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

        if (this.tokenDecoded.exp * 1000 < Date.now()) {
          this.router.navigate(['/register']);
        }

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
