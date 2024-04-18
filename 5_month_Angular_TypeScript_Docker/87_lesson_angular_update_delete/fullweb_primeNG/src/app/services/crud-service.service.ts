import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user-model';
import { CreateUser } from '../models/create-user';
export interface Message {
  mes: string;
}
@Injectable({
  providedIn: 'root',
})
export class CrudServiceService {
  baseUrl: string = 'https://localhost:7189/api/User/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl + 'GetAll');
  }

  getById(id: number): Observable<CreateUser> {
    return this.http.get<CreateUser>(this.baseUrl + 'GetByUserId?id=' + id);
  }
  create(data: CreateUser): Observable<Message> {
    return this.http.post<Message>(this.baseUrl + 'CreateUser', data);
  }
  update(id: number, data: CreateUser): Observable<CreateUser> {
    return this.http.put<CreateUser>(this.baseUrl + 'UpdateUser?id=' + id, data);
  }
  delete(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + 'DeleteUser?id=' + id);
  }
}
