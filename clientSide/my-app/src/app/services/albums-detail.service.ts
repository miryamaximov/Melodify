import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AlbumsDetail } from '../classes/AlbumsDetail';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class AlbumsDetailService {
  url: string = 'https://localhost:7284/api/AlbumsDetail/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<AlbumsDetail>> {
    return this.http.get<Array<AlbumsDetail>>(this.url + 'GetAll');
  }

  getAllByAlbumId(albumId: number): Observable<Array<AlbumsDetail>> {
    return this.http.get<Array<AlbumsDetail>>(
      this.url + 'GetAllByAlbumId/' + albumId
    );
  }

  getByAlbumId(albumId: number): Observable<AlbumsDetail> {
    return this.http.get<AlbumsDetail>(this.url + 'GetByAlbumId/' + albumId);
  }

  getBySongId(songId: number): Observable<AlbumsDetail> {
    return this.http.get<AlbumsDetail>(this.url + 'GetBySongId/' + songId);
  }

  add(albumDetail: AlbumsDetail): Observable<Array<AlbumsDetail>> {
    return this.http.post<Array<AlbumsDetail>>(this.url + 'Post', albumDetail);
  }

  delete(songId: number): Observable<Array<AlbumsDetail>> {
    return this.http.delete<Array<AlbumsDetail>>(this.url + 'Delete/' + songId);
  }
}
