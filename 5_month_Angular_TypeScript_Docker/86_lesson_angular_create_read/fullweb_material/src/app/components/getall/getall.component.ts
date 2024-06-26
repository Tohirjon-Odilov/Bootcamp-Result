import { Component } from '@angular/core';
import { CrudService } from '../../services/crud.service';

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.scss',
})
export class GetallComponent {
  constructor(private crudService: CrudService) {}
  displayedColumns: string[] = [
    'id',
    'productName',
    'productPrice',
    'productDescription',
    'productPicture',
    'categoryName',
    'createdAt',
  ];
  dataSource = this.crudService.getAll();
}
