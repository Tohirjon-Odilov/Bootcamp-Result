import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../serices/crud.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-get-all',
  templateUrl: './get-all.component.html',
  styleUrl: './get-all.component.scss',
})
export class GetAllComponent implements OnInit {
  users!: User[];

  constructor(private crudService: CrudService) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.crudService.getAll().subscribe({
      next: (data) => {
        this.users = data;
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
