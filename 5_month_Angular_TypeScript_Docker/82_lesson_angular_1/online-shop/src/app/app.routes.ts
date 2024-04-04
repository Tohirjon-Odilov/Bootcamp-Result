import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { AboutComponent } from './components/pages/about/about.component';
import { ContactComponent } from './components/pages/contact/contact.component';
import { InfoComponent } from './components/pages/info/info.component';
import { StoreComponent } from './components/pages/store/store.component';
import { NotfoundComponent } from './components/pages/notfound/notfound.component';

export const routes: Routes = [
    {path: "", title: "Home Page", component: HomeComponent},
    {path: "home", title: "Home Page", component: HomeComponent},
    {path: "about", title: "About Page", component: AboutComponent},
    {path: "contact", title: "Contact Page", component: ContactComponent},
    {path: "info", title: "Info Page", component: InfoComponent},
    {path: "store", title: "Store Page", component: StoreComponent},
    {path: "**", title: "Not Found Page", component: NotfoundComponent},
];
