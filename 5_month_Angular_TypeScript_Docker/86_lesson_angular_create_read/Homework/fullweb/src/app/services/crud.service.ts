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

  baseUrl: string = "http://localhost:5025/api/User/"; 
  constructor(private http: HttpClient) { }
   
  getAll(): Observable<UserModel[]>{
    return this.http.get<UserModel[]>(this.baseUrl+'GetAll')
  }
  createUser(data: CreateUser):Observable<Message>{
    return this.http.post<Message>('http://localhost:5025/api/User/CreateUser', data)
  }
}
