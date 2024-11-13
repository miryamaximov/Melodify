import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PlaylistDetail } from '../classes/PlaylistDetail';

@Injectable({
  providedIn: 'root',
})
export class PlaylistDetailService {
  url: string = 'https://localhost:7284/api/PlaylistsDetail/';

  constructor(private http: HttpClient) {}
  getAll(): Observable<Array<PlaylistDetail>> {
    return this.http.get<Array<PlaylistDetail>>(this.url + 'GetAll');
  }

  getAllByPlaylistId(playlistId: number): Observable<Array<PlaylistDetail>> {
    return this.http.get<Array<PlaylistDetail>>(
      this.url + 'GetAllByPlaylistId/' + playlistId
    );
  }

  getByPlaylistId(playlistId: number): Observable<PlaylistDetail> {
    return this.http.get<PlaylistDetail>(
      this.url + 'GetByPlaylistId/' + playlistId
    );
  }

  getAllBySongId(songId: number): Observable<Array<PlaylistDetail>> {
    return this.http.get<Array<PlaylistDetail>>(
      this.url + 'GetAllBySongId/' + songId
    );
  }

  getBySongId(songId: number): Observable<PlaylistDetail> {
    return this.http.get<PlaylistDetail>(this.url + 'GetBySongId/' + songId);
  }

  add(detail: PlaylistDetail): Observable<Array<PlaylistDetail>> {
    return this.http.post<Array<PlaylistDetail>>(this.url + 'Post', detail);
  }

  delete(
    songId: number,
    playlistId: number
  ): Observable<Array<PlaylistDetail>> {
    return this.http.delete<Array<PlaylistDetail>>(
      this.url + 'Delete/' + songId + '/' + playlistId
    );
  }
}
