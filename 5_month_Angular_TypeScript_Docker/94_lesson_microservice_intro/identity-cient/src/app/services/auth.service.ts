import { Inject, inject, Injectable } from '@angular/core';
import { LoginRequest } from '../interfaces/login-request';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { LoginResponse } from '../interfaces/login-response';
import { Router } from '@angular/router';
import { RegisterRequest } from '../interfaces/register-request';
import { RegisterResponse } from '../interfaces/register-response';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}
  apiUrl = environment.apiUrl;
  tokenKey: string = 'token';
  router = inject(Router);

  login(data: LoginRequest): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(`${this.apiUrl}Users/Login`, data)
      .pipe(
        map((response) => {
          if (response.isSuccess) {
            localStorage.setItem(this.tokenKey, response.token);
          }
          this.router.navigate(['/student-profile']);
          return response;
        })
      );
  }

  logout() {
    localStorage.clear();
  }

  register(data: RegisterRequest): Observable<RegisterResponse> {
    data.roles = ['Student'];
    data.status = 'Active';
    return this.http
      .post<RegisterResponse>(`${this.apiUrl}Users/Register`, data)
      .pipe(
        map((response) => {
          console.log(response);
          if (response.isSuccess) {
            // localStorage.setItem(this.tokenKey, response)
          }
          this.router.navigate(['/login'])
          return response;
        })
      );
  }
}
