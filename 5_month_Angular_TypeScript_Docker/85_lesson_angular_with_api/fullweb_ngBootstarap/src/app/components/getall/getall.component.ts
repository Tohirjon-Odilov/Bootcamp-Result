import { CrudService } from './../../services/crud.service';
import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/user-model';

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.scss'
})
export class GetallComponent implements OnInit {
users!: UserModel[];
constructor(private crudService:CrudService){}
  ngOnInit(): void {
      this.getAllUsers();
  }
  getAllUsers(){
    this.crudService.getAll().subscribe({
      next: (data)=>{
        this.users=data;
      },
      error: (err)=>{
        console.log(err);
      }
    })
  }

}
