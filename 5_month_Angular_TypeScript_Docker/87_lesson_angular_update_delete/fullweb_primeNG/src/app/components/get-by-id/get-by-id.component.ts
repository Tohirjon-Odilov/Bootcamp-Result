import { Component } from '@angular/core';
import { CreateUser } from '../../models/create-user';
import { CrudServiceService } from '../../services/crud-service.service';

@Component({
  selector: 'app-get-by-id',
  templateUrl: './get-by-id.component.html',
  styleUrl: './get-by-id.component.scss',
})
export class GetByIdComponent {
  myId: number = 1;
  user: CreateUser = {
    fullName: '',
    email: '',
    password: '',
    login: '',
    role: '',
  };

  constructor(private http: CrudServiceService) {
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
