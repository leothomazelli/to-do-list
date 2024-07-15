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
   * Get all users registered in the database.
   * @returns a ServiceResponse<User> with the result for the operation.
   */
  getAll(): Observable<ServiceResponse<User[]>> {
    return this.apiService.get('User', 'GetAll');
  }

  /**
   * Method will make sure the user exists and is active, being true will be granted access to the platform.
   * @param user is the object who's going to be validated and authenticated.
   */
  login(user: User): Observable<ServiceResponse<User>> {
    return this.apiService.post(this.normalizeData(user), 'User', 'Login').pipe(
      tap((response: ServiceResponse<User>) => {
        if (!response.success) {
          return;
        }

        localStorage.setItem('user', btoa(JSON.stringify(response.data)));
        this.router.navigate(['']);
      })
    );
  }

  /**
   * Method will log the user off the platform, making so that he can't access through URL address.
   */
  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  /**
   * Check if the user is or isn't logged in.
   * @returns
   */
  isLogged(): boolean {
    return localStorage.getItem('user') ? true : false;
  }

  /**
   * Method that complements user object for login.
   * @param data user who's going to be complemented.
   * @returns data object with complementary info.
   */
  private normalizeData(data: User): User {
    data.id = 0;
    data.email = '';
    return data;
  }
}
