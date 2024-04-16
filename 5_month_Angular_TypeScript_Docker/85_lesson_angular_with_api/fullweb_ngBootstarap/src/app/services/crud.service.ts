import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  baseUrl: string = "http://localhost:5025/api/User/GetAll";
  constructor(private http:HttpClient) { }
  getAll(): Observable<UserModel[]>{
    return this.http.get<UserModel[]>(this.baseUrl)
  }
}
