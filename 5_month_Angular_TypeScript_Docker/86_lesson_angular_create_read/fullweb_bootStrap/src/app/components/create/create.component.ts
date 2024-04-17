import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../serices/crud.service';
import { CreateUser } from '../../models/createUser';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss',
})
export class CreateComponent {
  isSubmitted: boolean = false;

  resultData!: CreateUser;

  setValue: CreateUser = {
    name: '',
  };

  constructor(private crudService: CrudService) {}

  createUser(data: CreateUser) {
    this.crudService.create(data).subscribe({
      next: (result) => {
        this.resultData = result;
        console.log(result);
        this.isSubmitted = true;
      },
      error: (err) => {
        console.dir(err);
      },
    });
  }

  setUser() {
    this.createUser(this.setValue);
  }
}
