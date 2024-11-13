import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../classes/User';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  url: string = 'https://localhost:7284/api/User/';

  isAdmin:boolean = false  //האם המשתמש הנוכחי הוא מנהל
  currUser:User = new User()   //המשתמש הנוכחי
  isConnect:boolean = false  //האם יש משתמש שמחובר עכשיו

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<User>> {
    return this.http.get<Array<User>>(this.url + 'GetAll');
  }

  getById(userId: number): Observable<User> {
    return this.http.get<User>(this.url + 'GetById/' + userId);
  }

  getByPassword(password: string): Observable<User> {
    return this.http.get<User>(this.url + 'GetByPassword/' + password);
  }

  getByEmail(email: string): Observable<User> {
    return this.http.get<User>(this.url + 'GetByEmail/' + email);
  }

  getByNameAndPassword(name: string, password: string) : Observable<User>{
    return this.http.get<User>(this.url+'GetByNameAndPassword/'+name+'/'+password)
  }

  add(user: User): Observable<Array<User>> {
    return this.http.post<Array<User>>(this.url + 'Post', user);
  }

  update(user: User): Observable<Array<User>> {
    return this.http.put<Array<User>>(this.url + 'Put', user);
  }

  delete(userId: number): Observable<Array<User>> {
    return this.http.delete<Array<User>>(this.url + 'Delete/' + userId);
  }
}
