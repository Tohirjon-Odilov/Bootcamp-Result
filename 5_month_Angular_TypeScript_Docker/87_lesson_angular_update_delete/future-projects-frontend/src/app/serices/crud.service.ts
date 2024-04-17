import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { CreateUser } from '../models/createUser';

@Injectable({
  providedIn: 'root',
})
export class CrudService {
  baseUrl: string = 'https://localhost:7189/api/User/';

  constructor(private http: HttpClient) {}

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'GetAll');
  }

  create(data: CreateUser): Observable<CreateUser> {
    return this.http.post<CreateUser>(this.baseUrl + 'CreateUser', data);
  }

  getById(id: number): Observable<CreateUser> {
    return this.http.get<CreateUser>(this.baseUrl + `GetByUserId?id=${id}`);
  }

  update(id: number, data: CreateUser): Observable<CreateUser> {
    return this.http.put<CreateUser>(
      this.baseUrl + `UpdateUser?id=${id}`,
      data
    );
  }

  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + `DeleteUser?id=${id}`);
  }
}
