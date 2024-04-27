import { jwtDecode } from 'jwt-decode';
import { Injectable, inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Route,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { DecodedModel } from '../interfaces/decoded-model';

var loggedInUser: any;

var decoded: DecodedModel;

try {
  const decoded: DecodedModel = jwtDecode(localStorage.getItem('token')!);

  loggedInUser = {
    id: decoded.nameid,
    name: decoded.name,
    role: decoded.role,
    email: decoded.email,
  };
} catch {
  loggedInUser = {
    id: '',
    name: '',
    role: '',
    email: '',
  };
}

// console.log(loggedInUser);

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  tokenDecoded: any;
  constructor(private router: Router) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const { role } = loggedInUser;

    const { routeConfig } = route;
    const { path } = routeConfig as Route;

    // this.tokenDecoded = jwtDecode(localStorage.getItem('token')!);
    
    // if (this.tokenDecoded && this.tokenDecoded.exp * 1000 < Date.now()) {
    //   console.log(this.tokenDecoded);
    //   return false;
    // }
    console.log("adguard")

    if (
      path?.includes('') ||
      path?.includes('student-profile') ||
      path?.includes('home') && role === 'Admin'
    ) {
      return true;
    }

    // if (path?.includes('student-profile') && role === 'customer') {
    //   return true;
    // }

    this.router.navigateByUrl('/login');
    return false;
  }
}
