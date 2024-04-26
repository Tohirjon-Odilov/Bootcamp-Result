import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { UsersComponent } from './admin/users/users.component';
import { StudentProfileComponent } from './admin/students/student-profile/student-profile.component';
import { ForbiddenComponent } from './pages/forbidden/forbidden.component';
import { AuthGuard } from './guards/auth.guard';
import { TaskComponent } from './pages/task/task.component';

const routes: Routes = [
 { path: '', component: HomeComponent, canActivate: [AuthGuard] },
 { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
 { path: 'login', component: LoginComponent },
 { path: 'register', component: RegisterComponent },
 { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
 { path: 'student-profile', component: StudentProfileComponent, canActivate: [AuthGuard] },
 { path: 'forbidden', component: ForbiddenComponent },
 { path: 'task', component: TaskComponent },
 { path: '**', component: HomeComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
