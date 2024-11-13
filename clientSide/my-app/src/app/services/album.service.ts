import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from '../classes/Album';

@Injectable({
  providedIn: 'root',
})
export class AlbumService {
  url: string = 'https://localhost:7284/api/Album/';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Album>> {
    return this.http.get<Array<Album>>(this.url + 'GetAll');
  }

  GetByAlbumId(albumId: number): Observable<Album> {
    return this.http.get<Album>(this.url + 'GetByAlbumId/' + albumId);
  }

  GetAllBySingerId(singerId: number): Observable<Array<Album>> {
    return this.http.get<Array<Album>>(
      this.url + 'GetAllBySingerId/' + singerId
    );
  }

  GetBySingerId(singerId: number): Observable<Album> {
    return this.http.get<Album>(this.url + 'GetBySingerId/' + singerId);
  }

  add(album: Album): Observable<Array<Album>> {
    return this.http.post<Array<Album>>(this.url + 'Post', album);
  }

  update(album: Album): Observable<Array<Album>> {
    return this.http.put<Array<Album>>(this.url + 'Put', album);
  }

  delete(albumId: number): Observable<Array<Album>> {
    return this.http.delete<Array<Album>>(this.url + 'Delete/' + albumId);
  }
}
