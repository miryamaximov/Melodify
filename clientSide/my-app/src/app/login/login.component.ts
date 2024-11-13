import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../services/user.service';
import { User } from '../classes/User';
import { isEmpty } from 'rxjs';
import { Router, RouterModule } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterModule, NgIf],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  constructor(public userServ: UserService, public router: Router) {}
  name: string = '';
  password: string = '';

  login() {
    if (
      this.name.toLowerCase() == 'admin' &&
      this.password.toLowerCase() == 'admin'
    ) {
      this.userServ.isAdmin = true;
      this.userServ.getByNameAndPassword('Admin', 'Admin').subscribe(
        (data) => {
          this.userServ.currUser = data;
          this.userServ.isConnect = true
        },
        (err) => {
          console.log(err);
        }
      );
    } else {
      this.userServ.getByNameAndPassword(this.name, this.password).subscribe(
        (data) => {
          this.userServ.currUser = data;
          this.userServ.isConnect = true
        },
        (err) => {
          if (err.status == 404) {
            this.router.navigate(['/signup']);
          }
          console.log(err);
        }
      );
    }
    this.router.navigate(['/home']);
  }
}
