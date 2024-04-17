import { CrudServiceService } from './../../services/crud-service.service';
import { Component } from '@angular/core';
import { UserModel } from '../../models/user-model';

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.scss'
})
export class GetallComponent {
  products!: UserModel[];
  
  constructor(private CrudService: CrudServiceService) {}
  
  ngOnInit() {
      this.CrudService.getAll().subscribe({
        next:(data)=>{
          this.products=data;
          console.log(data)
        },
        error: (err)=>{
          console.log(err);
        }
      }) 
      

  }
}
