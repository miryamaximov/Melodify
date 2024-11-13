import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Playlist } from '../classes/Playlist';

@Injectable({
  providedIn: 'root',
})
export class PlaylistService {
  url: string = 'https://localhost:7284/api/Playlist/';
  constructor(private http: HttpClient) {}

  getAllNotActive(): Observable<Array<Playlist>> {
    return this.http.get<Array<Playlist>>(this.url + 'GetAllNotActive');
  }

  getByIdNotActive(playlistId: number): Observable<Playlist> {
    return this.http.get<Playlist>(this.url + 'GetByIdNotActive/' + playlistId);
  }

  getAllByUserIdNotActive(userId: number): Observable<Array<Playlist>> {
    return this.http.get<Array<Playlist>>(
      this.url + 'GetAllByUserIdNotActive/' + userId
    );
  }

  getAll(): Observable<Array<Playlist>> {
    return this.http.get<Array<Playlist>>(this.url + 'GetAll');
  }

  getById(playlistId: number): Observable<Playlist> {
    return this.http.get<Playlist>(this.url + 'GetById/' + playlistId);
  }

  getAllByUserId(userId: number | undefined): Observable<Array<Playlist>> {
    return this.http.get<Array<Playlist>>(
      this.url + 'GetAllByUserId/' + userId
    );
  }

  getByUserId(userId: number): Observable<Playlist> {
    return this.http.get<Playlist>(this.url + 'GetByUserId/' + userId);
  }

  add(playlist: Playlist): Observable<Array<Playlist>> {
    return this.http.post<Array<Playlist>>(this.url + 'Post', playlist);
  }

  update(playlist: Playlist): Observable<Array<Playlist>> {
    return this.http.put<Array<Playlist>>(this.url + 'Put', playlist);
  }

  delete(playlistId: number): Observable<Array<Playlist>> {
    return this.http.delete<Array<Playlist>>(this.url + 'Delete/' + playlistId);
  }
}
