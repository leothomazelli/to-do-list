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
   * @returns
   */
  getAll(): Observable<ServiceResponse<User[]>> {
    return this.apiService.get('User', 'GetAll');
  }

  /**
   *
   * @param user
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
   *
   */
  logout() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  /**
   *
   * @returns
   */
  isLogged(): boolean {
    return localStorage.getItem('user') ? true : false;
  }

  /**
   *
   * @param data
   * @returns
   */
  private normalizeData(data: User): User {
    data.id = 0;
    data.email = '';
    return data;
  }
}
