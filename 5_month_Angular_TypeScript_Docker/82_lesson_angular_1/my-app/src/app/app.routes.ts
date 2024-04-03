import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { FooterComponent } from './components/footer/footer.component';

export const routes: Routes = [
    {path: "home", title: "Home Page", component: HomeComponent},
    {path: "**", title: "Home Page", component: FooterComponent},
];
