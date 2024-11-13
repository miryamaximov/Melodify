import { Component } from '@angular/core';
import { User } from '../classes/User';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { NgClass, NgIf } from '@angular/common';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, NgIf],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css',
})
export class SignupComponent {
  myForm: FormGroup = new FormGroup({
    username: new FormControl(null, Validators.required),
    useremail: new FormControl(null, [Validators.required, Validators.email]),
    userpassword: new FormControl(null, Validators.required),
  });

  getUserName() {
    return this.myForm.controls['username'];
  }
  getUserEmail() {
    return this.myForm.controls['useremail'];
  }
  getUserPassword() {
    return this.myForm.controls['userpassword'];
  }

  constructor(public userServ: UserService, public router: Router) {}

  name: string = '';
  password: string = '';
  email: string = '';
  user: User = new User();

  signup() {
    // אם אתה מנהל
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
    } else  //אם מדובר במשתמש קיים אבל לא מנהל מעבירים אותו להתחברות
    {
      this.userServ.getByNameAndPassword(this.name, this.password).subscribe(
        (data) => {
          if (data.userEmail?.toLowerCase() == this.email.toLowerCase()) {
            this.router.navigate(['/login']);
          } else // אם מדובר במשתמש חדש רושמים אותו
          {
            this.user.isAdmin = false;
            this.user.numOfPlaylists = 0;
            this.user.userEmail = this.email;
            this.user.userName = this.name;
            this.user.userPass = this.password;
             
            this.userServ.add(this.user).subscribe(
              (data) => {
                console.log(data);
                console.log(this.user);
                
                //מהפונקציה הזאת חוזרת רשימת כל המשתמשים הנוכחית,האם יש לי מה לעשות איתה???
              },
              (err) => {
                console.log(err);
              }
            );
          }
        },
        (err) => {
          if (err.status == 404) {
            this.user.isAdmin = false;
            this.user.numOfPlaylists = 0;
            this.user.userEmail = this.email;
            this.user.userName = this.name;
            this.user.userPass = this.password;     
            this.userServ.add(this.user).subscribe(
              (data) => {
                //מהפונקציה הזאת חוזרת רשימת כל המשתמשים הנוכחית,האם יש לי מה לעשות איתה???
                console.log(data);
                console.log(this.user);
              },
              (err) => {
                console.log(err);
              }
            );
            
          }
        }
      );
    }
    this.userServ.currUser = this.user;
    this.userServ.isConnect = true
    this.router.navigate(['/home']);
  }
}
