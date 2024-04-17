import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { CreateUser } from '../models/createUser';

@Injectable({
  providedIn: 'root',
})
export class CrudService {
  baseUrl: string = 'https://api.tohirjon.uz/api/';

  constructor(private http: HttpClient) {}

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'Product/GetAll');
  }

  create(data: CreateUser): Observable<CreateUser> {
    return this.http.post<CreateUser>(this.baseUrl + 'Category/Create', data);
  }
}
