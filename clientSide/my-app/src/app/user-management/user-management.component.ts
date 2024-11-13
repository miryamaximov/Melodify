import { NgFor, NgStyle } from '@angular/common';
import { Component } from '@angular/core';
import { User } from '../classes/User';
import { UserService } from '../services/user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [NgFor, NgStyle, FormsModule],
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.css',
})
export class UserManagementComponent {
  // An array to hold the list of users.
  users: Array<User> = new Array<User>();
  isFormVisible: boolean = false;

  //the inputs to edit the user
  name: string | undefined = '';
  password: string | undefined = '';
  email: string | undefined = '';
  admin: boolean | undefined = false;
  id: number = 0;

  userForUpdate: User = new User();

  constructor(public userServ: UserService) {
    userServ.getAll().subscribe(
      (data) => {
        this.users = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deleteUser(userId: any) {
    this.userServ.delete(userId).subscribe(
      (data) => {
        this.users = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  confirmDeleteUser(userId: any) {
    const confirmation = window.confirm('האם אתה בטוח שברצונך למחוק משתמש זה?');
    if (confirmation) {
      this.deleteUser(userId);
    }
  }
  editUser(userId: any) {
    this.isFormVisible = true;
    //הצבת הפרטים המקוריים של המשתמש לשדות הקלט
    this.userServ.getById(userId).subscribe(
      (data) => {
        (this.name = data.userName), (this.password = data.userPass);
        this.email = data.userEmail;
        this.admin = data.isAdmin;
        this.id = userId;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  save() {
    this.userForUpdate.userId = this.id;
    this.userForUpdate.userName = this.name;
    this.userForUpdate.userEmail = this.email;
    this.userForUpdate.userPass = this.password;
    this.userForUpdate.isAdmin = this.admin == true ? true : false;

    this.userServ.update(this.userForUpdate).subscribe(
      (data) => {
        this.users = data;
      },
      (err) => {
        console.log(err);
      }
    );
    this.isFormVisible = false;
  }
}
