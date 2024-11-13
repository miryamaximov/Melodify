import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Song } from '../classes/Song';

@Injectable({
  providedIn: 'root',
})
export class SongService {
  url: string = 'https://localhost:7284/api/Song/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(this.url + 'GetAll');
  }

  //לבדוק אם אפשר להצליח להחזיר את הסוג של הקוד
  getBySongId(songId: any): Observable<Song> {
    return this.http.get<Song>(this.url + 'GetBySongId/' + songId);
  }

  getAllBySingerId(singerId: number): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetAllBySingerId/' + singerId
    );
  }

  getBySingerId(singerId: number): Observable<Song> {
    return this.http.get<Song>(this.url + 'GetBySingerId/' + singerId);
  }

  getByNumLikes(numLikes: number): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(this.url + 'GetByNumLikes/' + numLikes);
  }

  getByNumLikesAbove(numLikes: number): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByNumLikesAbove/' + numLikes
    );
  }

  getByNumLikesLess(numLikes: number): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByNumLikesLess/' + numLikes
    );
  }

  getByPublishingDate(publishingDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByPublishingDate/' + publishingDate
    );
  }

  getByPublishingDateAfter(publishingDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByPublishingDateAfter/' + publishingDate
    );
  }

  getByPublishingDateBefore(publishingDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByPublishingDateBefore/' + publishingDate
    );
  }

  getByUploadDate(uploadDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByUploadDate/' + uploadDate
    );
  }

  getByUploadDateAfter(uploadDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByUploadDateAfter/' + uploadDate
    );
  }

  getByUploadDateBefore(uploadDate: Date): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(
      this.url + 'GetByUploadDateBefore/' + uploadDate
    );
  }

  getByStr(str: string): Observable<Array<Song>> {
    return this.http.get<Array<Song>>(this.url + 'GetByStr/' + str);
  }

  add(song: Song): Observable<Array<Song>> {
    return this.http.post<Array<Song>>(this.url + 'Post', song);
  }

  update(song: Song): Observable<Array<Song>> {
    return this.http.put<Array<Song>>(this.url + 'Put', song);
  }

  delete(songId: number): Observable<Array<Song>> {
    return this.http.delete<Array<Song>>(this.url + 'Delete/' + songId);
  }
}
