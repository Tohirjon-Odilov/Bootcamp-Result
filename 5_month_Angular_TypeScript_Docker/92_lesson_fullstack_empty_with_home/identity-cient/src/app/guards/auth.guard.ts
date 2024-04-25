import { jwtDecode } from 'jwt-decode';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Route,
  Router,
  RouterStateSnapshot,
  UrlSegment,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { DecodedModel } from '../interfaces/decoded-model';

// hardcoded user data.

var loggedInUser: any;

var decoded: DecodedModel;

try{
  const decoded: DecodedModel = jwtDecode(localStorage.getItem("token")!);

  loggedInUser = {
    id: decoded.nameid,
    name: decoded.name,
    role: decoded.role,
    email: decoded.email
  };
}
catch{
  loggedInUser = {
    id: '',
    name: '',
    role: '',
    email: ''
  };
}

// console.log(decoded)


console.log(loggedInUser)

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  // inject the router service to allow navigation.
  constructor(private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const { role } = loggedInUser;

    // provides the route configuration options.
    const { routeConfig } = route;
console.log(routeConfig)
    // provides the path of the route.
    const { path } = routeConfig as Route;

    if (path?.includes('student-profile') && role === 'Admin') {
      // if user is administrator and is trying to access admin routes, allow access.
      // this.router.navigateByUrl('/');
      
      return true;
    }
    
    if (path?.includes('student-profile') && role === 'customer') {
      // this.router.navigateByUrl('/');
      // if user is customer and is accessing customer route, allow access.

      return true;
    }

    if (
      (path?.includes('guest') || path?.includes('home')) &&
      (role === 'customer' || role === 'administrator')
    ) {
      // if a logged in user goes to Guest or Home, navigate to their respective dashboard.

      this.router.navigateByUrl(role === 'customer' ? '/customer' : '/admin');
      return false;
    }

    // for any other condition, navigate to the forbidden route.

    this.router.navigateByUrl('/login');
    return false;
  }
}
