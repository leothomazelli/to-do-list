import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';
import { User } from 'src/app/models/User';
import { Observable, tap } from 'rxjs';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private apiService: ApiService, private router: Router) {}

  /**
   *
   * @param user
   */
  login(userName: string, password: string): Observable<ServiceResponse<User>> {
    return this.apiService
      .post({ userName: userName, password: password }, 'User', 'Login')
      .pipe(
        tap((response: ServiceResponse<User>) => {
          if (!response.success) {
            return;
          }

          localStorage.setItem(
            'token',
            btoa(JSON.stringify(response.data.token))
          );
          localStorage.setItem('user', btoa(JSON.stringify(response.data)));
          this.router.navigate(['']);
        })
      );
  }

  /**
   *
   */
  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  // /**
  //  *
  //  * @returns
  //  */
  // userLogged(): User {
  //   return localStorage.getItem('usuario')
  //     ? JSON.parse(atob(localStorage.getItem('user')))
  //     : null;
  // }

  // /**
  //  *
  //  * @returns
  //  */
  // userIdLogged(): string {
  //   return localStorage.getItem('usuario')
  //     ? (JSON.parse(atob(localStorage.getItem('usuario'))) as IUsuario).id
  //     : null;
  // }

  // /**
  //  *
  //  * @returns
  //  */
  // userToken(): string {
  //   return localStorage.getItem('token')
  //     ? JSON.parse(atob(localStorage.getItem('token')))
  //     : null;
  // }

  /**
   *
   * @returns
   */
  isLogged(): boolean {
    return localStorage.getItem('token') ? true : false;
  }
}
