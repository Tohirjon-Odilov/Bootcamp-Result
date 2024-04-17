import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/user-model';
import { CrudService } from '../../services/crud.service';


@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.scss',


})






export class GetallComponent {

constructor(private crudService:CrudService){}
displayedColumns: string[] = ['userId', 'fullName', 'email', 'role'];
dataSource = this.crudService.getAll();

}
