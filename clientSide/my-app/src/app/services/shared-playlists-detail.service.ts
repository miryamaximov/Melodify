import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SharedPlaylistsDetail } from '../classes/SharedPlaylistsDetail';

@Injectable({
  providedIn: 'root',
})
export class SharedPlaylistsDetailService {
  url: string = 'https://localhost:7284/api/SharedPlaylistsDetail/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<SharedPlaylistsDetail>> {
    return this.http.get<Array<SharedPlaylistsDetail>>(this.url + 'GetAll');
  }

  getAllByPlaylistId(
    playlistId: number
  ): Observable<Array<SharedPlaylistsDetail>> {
    return this.http.get<Array<SharedPlaylistsDetail>>(
      this.url + 'GetAllByPlaylistId/' + playlistId
    );
  }

  getByPlaylistId(playlistId: number): Observable<SharedPlaylistsDetail> {
    return this.http.get<SharedPlaylistsDetail>(
      this.url + 'GetByPlaylistId/' + playlistId
    );
  }

  getAllByUserId(userId: number): Observable<Array<SharedPlaylistsDetail>> {
    return this.http.get<Array<SharedPlaylistsDetail>>(
      this.url + 'GetAllByUserId/' + userId
    );
  }

  getByUserId(userId: number): Observable<SharedPlaylistsDetail> {
    return this.http.get<SharedPlaylistsDetail>(
      this.url + 'GetByUserId/' + userId
    );
  }

  add(detail: SharedPlaylistsDetail): Observable<Array<SharedPlaylistsDetail>> {
    return this.http.post<Array<SharedPlaylistsDetail>>(
      this.url + 'Post',
      detail
    );
  }

  delete(
    playlistId: number,
    userId: number
  ): Observable<Array<SharedPlaylistsDetail>> {
    return this.http.delete<Array<SharedPlaylistsDetail>>(
      this.url + 'Delete/' + playlistId + '/' + userId
    );
  }
}
