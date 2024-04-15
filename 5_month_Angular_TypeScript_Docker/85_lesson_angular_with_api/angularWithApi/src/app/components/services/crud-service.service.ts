import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class CrudServiceService {
  constructor(private http: HttpClient) {}
  getAll(): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:7226/api/Product/GetAll');
  }
}
