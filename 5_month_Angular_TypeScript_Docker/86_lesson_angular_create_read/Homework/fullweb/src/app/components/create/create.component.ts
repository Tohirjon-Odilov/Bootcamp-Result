import { CrudService, Message } from './../../services/crud.service';
import { Component } from '@angular/core';
import { CreateUser } from '../../models/create-user';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {
    resultData!:Message;
    isSubmitted:boolean = false;
    setValue: CreateUser = {
      fullName: "",
      email: "",
      login: "",
      password: "",
      role: ""
    }
    constructor(private crudService:CrudService){}


    create(data:CreateUser){
        this.crudService.createUser(data).subscribe({
          next: (result)=>{
            this.resultData=result;
            this.isSubmitted=true;
            console.log(result);
          },
          error:(err)=>{
            console.log(err);
          }
        });
    }
    lets(){
      this.create(this.setValue);
    }
}

