import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'identity-cient';

  router = inject(Router);
  tokenKey = 'token' 
  tokenDecoded : any;

  ngOnInit(): void {
    this.tokenDecoded = jwtDecode(localStorage.getItem(this.tokenKey)!)
      if(this.tokenDecoded.exp * 1000 < Date.now()){
        this.router.navigate(['/login'])
      }
  }
}
