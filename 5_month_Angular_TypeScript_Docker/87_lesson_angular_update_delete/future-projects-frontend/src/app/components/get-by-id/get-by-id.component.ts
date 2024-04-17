import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../serices/crud.service';
import { CreateUser } from '../../models/createUser';

@Component({
  selector: 'app-get-by-id',
  templateUrl: './get-by-id.component.html',
  styleUrl: './get-by-id.component.scss',
})
export class GetByIdComponent {
  myId: number = 1;
  user: CreateUser = {
    userId: 0,
    fullName: '',
    email: '',
    password: '',
    login: '',
    role: '',
  };

  constructor(private http: CrudService) {
    this.getById();
  }

  // ngOnInit(): void {
  //   this.getById();
  // }

  getById() {
    this.http.getById(this.myId).subscribe({
      next: (data) => {
        this.user = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
