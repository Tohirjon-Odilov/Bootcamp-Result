import { Component } from '@angular/core';
import { CreateUser } from '../../models/createUser';
import { CrudService } from '../../serices/crud.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent {
  myId!: number;
  user: CreateUser = {
    name: "",
    email: "",
    password: "",
    login: "",
    role: ""
  };

  setValue: CreateUser = {
    name: "",
    email: "",
    password: "",
    login: "",
    role: ""
  };

  constructor(private http : CrudService){
    this.getById();
  }

  ngOnInit(): void {

    this.getById();

  }



  getById(){

    this.http.getById(this.myId).subscribe({
      next: (data) => {
        this.user = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      }
    })

  }

  setUser(){
    this.http.update(this.myId, this.setValue).subscribe({
      next: (data) => {
        this.user = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }


}
