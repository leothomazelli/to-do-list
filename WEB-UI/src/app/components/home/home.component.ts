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
   * Method that will logout the user, disabling his authentication to travel through URLs, needing to log back in again.
   */
  logout(): void {
    this.userService.logout();
  }
}
