import { Component } from '@angular/core';
import { CreateUser } from '../../models/create-user';
import { CrudService, Message } from '../../services/crud.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {
isSubmited:boolean=false;
setValue:CreateUser={
  fullName: "",
  email: "",
  login: "",
  password: "",
  role: ""
}
resultData!:Message;
constructor(private crud:CrudService){}
create(data:CreateUser){
  this.crud.create(data).subscribe({
    next: (res)=>{
      this.resultData=res;
      this.isSubmited=true;
    },
    error: (err)=>{
      console.log(err)
    }

  });

}
start(){
  this.create(this.setValue);
}
}
