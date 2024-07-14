import { Component } from '@angular/core';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  constructor(private userService: UserService) {}

  /**
   *
   * @returns
   */
  logout(): void {
    this.userService.logout();
  }
}
