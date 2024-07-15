import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formLogin!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  /**
   * Method that creates the login and its validators.
   */
  createLoginForm() {
    this.formLogin = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  /**
   * Method responsible for login.
   */
  login() {
    if (this.formLogin == null || this.formLogin?.invalid) {
      return;
    }

    var user = this.formLogin.getRawValue() as User;
    this.userService.login(user).subscribe((response) => {
      if (!response.success) {
        this.snackBar.open(
          'Falha na autenticação',
          'Usuário ou senha incorretos.',
          {
            duration: 3000,
          }
        );
      }
    });
  }
}
