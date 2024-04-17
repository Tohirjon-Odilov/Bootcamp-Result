import { Component } from '@angular/core';
import { CreateUser } from '../../models/createUser';
import { CrudService } from '../../serices/crud.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.scss',
})
export class DeleteComponent {
  myId: number = 1;
  user: boolean = false;

  setValue: CreateUser = {
    fullName: '',
    email: '',
    password: '',
    login: '',
    role: '',
  };

  constructor(private http: CrudService) {
    this.deleteById();
  }

  // ngOnInit(): void {
  //   this.getById();
  // }

  deleteById() {
    this.http.deleteById(this.myId).subscribe({
      next: (data) => {
        this.user = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  setUser() {
    this.http.update(this.myId, this.setValue).subscribe({
      next: (data) => {
        this.user = true;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
