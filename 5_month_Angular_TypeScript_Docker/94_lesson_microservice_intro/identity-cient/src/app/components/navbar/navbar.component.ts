import { AuthService } from './../../services/auth.service';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  authService = inject(AuthService);

  logout() {
    this.authService.logout();
  }
}
