import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Singer } from '../classes/Singer';

@Injectable({
  providedIn: 'root',
})
export class SingerService {
  url: string = 'https://localhost:7284/api/Singer/';
  constructor(private http: HttpClient) {}

  getAllNotActive(): Observable<Array<Singer>> {
    return this.http.get<Array<Singer>>(this.url + 'GetAllNotActive');
  }

  getAll(): Observable<Singer[]> {
    return this.http.get<Array<Singer>>(this.url + 'GetAll');
  }

  getById(singerId: number): Observable<Singer> {
    return this.http.get<Singer>(this.url + 'GetById/' + singerId);
  }

  GetByStr(str: string): Observable<Array<Singer>> {
    return this.http.get<Array<Singer>>(this.url + 'GetByStr/' + str);
  }

  add(singer: Singer): Observable<Array<Singer>> {
    return this.http.post<Array<Singer>>(this.url + 'Post', singer);
  }

  update(singer: Singer): Observable<Array<Singer>> {
    return this.http.put<Array<Singer>>(this.url + 'Put', singer);
  }

  delete(singerId: number): Observable<Array<Singer>> {
    return this.http.delete<Array<Singer>>(this.url + 'Delete/' + singerId);
  }

  deleteCompletely(singerId: number): Observable<Array<Singer>> {
    return this.http.delete<Array<Singer>>(
      this.url + 'DeleteCompletely/' + singerId
    );
  }
}
