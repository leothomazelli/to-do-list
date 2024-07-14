import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { EditComponent } from './components/edit/edit.component';
import { AddComponent } from './components/add/add.component';
import { ToDoListComponent } from './components/home/components/to-do-list/to-do-list.component';
import { AuthGuard } from './services/guards/auth.guard';
import { UnauthGuard } from './services/guards/unauth.guard';

const routes: Routes = [
  {
    path: 'login',
    canActivate: [UnauthGuard],
    component: LoginComponent,
  },
  {
    path: '',
    canActivate: [AuthGuard],
    component: HomeComponent,
    children: [
      {
        path: '',
        canActivate: [AuthGuard],
        component: ToDoListComponent,
      },
      {
        path: 'home',
        canActivate: [AuthGuard],
        component: ToDoListComponent,
      },
      {
        path: 'add',
        canActivate: [AuthGuard],
        component: AddComponent,
      },
      {
        path: 'edit/:id',
        canActivate: [AuthGuard],
        component: EditComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
