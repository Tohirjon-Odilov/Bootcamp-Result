import { Component } from '@angular/core';
import { CreateUser } from '../../models/create-user';
import { CrudServiceService, Message } from '../../services/crud-service.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {
setValue:CreateUser={
  fullName:"",
  email:"",
  login:"",
  password:"",
  role:""

}
resultdata!:Message;
isSubmited:boolean=false;
constructor(private crud:CrudServiceService){}
create(data:CreateUser){
this.crud.create(data).subscribe({
  next: (res)=>{
    this.resultdata=res;
    this.isSubmited=true;
  },
  error: (err)=>{
    console.log(err);
  }
});
}
start(){
  this.create(this.setValue);
}
}
