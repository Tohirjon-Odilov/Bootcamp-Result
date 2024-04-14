import { Routes } from '@angular/router';
import {HomeComponent} from "./components/pages/home/home.component";
import {NotfoundComponent} from "./components/pages/notfound/notfound.component";
import { InputComponent } from './components/pages/input/input.component';
import { ProfileComponent } from './components/pages/profile/profile.component';

export const routes: Routes = [
  {path: "", title: "Home page", component: HomeComponent},
  {path: "home", title: "Home page", component: HomeComponent},
  {path: "input", title: "Input page", component: InputComponent},
  {path: "profile", title: "Profile page", component: ProfileComponent},
  {path: "**", title: "Not Found", component: NotfoundComponent},
];
