import { CrudServiceService } from './../../services/crud-service.service';
import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {  OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { User } from '../../models/user';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HttpClientModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
// export class HomeComponent implements OnInit {
//   users!: User[];

//   constructor(private CrudServiceService: CrudServiceService) {}
//   ngOnInit(): void {
//     this.getAllUsers();
//   }
//   getAllUsers() {
//     this.CrudServiceService.getAll().subscribe({
//       next: (data) => {
//         console.log(data);
//         // this.users = data
//       },
//       error: (error) => {
//         console.log(error);
//       },
//     });
//   }
// }
export class HomeComponent implements OnInit {
  users: User[] = []; // Initialize programmers as an empty array
  constructor(private CrudServiceService: CrudServiceService) {}

  ngOnInit(): void {
    // Corrected lifecycle hook name
    this.getAllProgrammers();
  }

  getAllProgrammers(): void {
    // Added return type void
    this.CrudServiceService.getAll().subscribe({
      next: (data) => {
        this.users = data;
        console.log(data);
      },
      error: (error) => {
        // Corrected error handling syntax
        console.log('error', error); // Log the error message
      },
    });
  }
}