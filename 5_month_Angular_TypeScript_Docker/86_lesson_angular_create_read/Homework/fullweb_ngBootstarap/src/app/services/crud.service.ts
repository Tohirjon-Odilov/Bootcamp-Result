import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user-model';
import { CreateUser } from '../models/create-user';

export interface Message {
  fullName:string,

}
@Injectable({
  providedIn: 'root'
})

export class CrudService {

  baseUrl: string = "https://localhost:7189/api/User/GetAll";
  constructor(private http:HttpClient) { }
  getAll(): Observable<UserModel[]>{
    return this.http.get<UserModel[]>(this.baseUrl)
  }
  createUser(data: CreateUser):Observable<Message>{
    return this.http.post<Message>(this.baseUrl+'CreateUser', data)
  }
}
