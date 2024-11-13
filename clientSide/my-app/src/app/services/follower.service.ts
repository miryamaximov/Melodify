import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Follower } from '../classes/Follower';

@Injectable({
  providedIn: 'root',
})
export class FollowerService {
  url: string = 'https://localhost:7284/api/Follower/';
  constructor(private http: HttpClient) {}
  getAll(): Observable<Array<Follower>> {
    return this.http.get<Array<Follower>>(this.url + 'GetAll');
  }

  getAllByUserId(userId: number): Observable<Array<Follower>> {
    return this.http.get<Array<Follower>>(
      this.url + 'GetAllByUserId/' + userId
    );
  }

  getByUserId(userId: number): Observable<Follower> {
    return this.http.get<Follower>(this.url + 'GetByUserId/' + userId);
  }

  getAllBySingerId(singerId: number): Observable<Array<Follower>> {
    return this.http.get<Array<Follower>>(
      this.url + 'GetAllBySingerId/' + singerId
    );
  }

  getBySingerId(singerId: number): Observable<Follower> {
    return this.http.get<Follower>(this.url + 'GetBySingerId/' + singerId);
  }

  add(follower: Follower): Observable<Array<Follower>> {
    return this.http.post<Array<Follower>>(this.url + 'Post', follower);
  }

  delete(userId: number, singerId: number): Observable<Array<Follower>> {
    return this.http.delete<Array<Follower>>(
      this.url + 'Delete/' + userId + '/' + singerId
    );
  }
}
