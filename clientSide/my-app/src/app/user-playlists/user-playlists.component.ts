import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { PlaylistService } from '../services/playlist.service';
import { Playlist } from '../classes/Playlist';
import { Song } from '../classes/Song';
import { PlaylistDetailService } from '../services/playlist-detail.service';
import { PlaylistDetail } from '../classes/PlaylistDetail';
import { SongService } from '../services/song.service';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-user-playlists',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './user-playlists.component.html',
  styleUrl: './user-playlists.component.css',
})
export class UserPlaylistsComponent {
  playlists: Array<Playlist> = new Array<Playlist>(); //מערך הפלייליסטים של המשתמש
  songs: Array<Song> = new Array<Song>(); //מערך שיחזיק את השירים של הפלייליסט שרוצים לשמוע
  details: Array<PlaylistDetail> = new Array<PlaylistDetail>(); //מערך עזר שיחזיק את פרטי השירים של הפלייליסט
  constructor(
    public userService: UserService,
    public playlistServ: PlaylistService,
    public playlistDetailServ: PlaylistDetailService,
    public songServ: SongService,
    public route: Router
  ) {
    if (userService.isConnect) {
      console.log(userService.currUser.userId);

      playlistServ.getAllByUserId(userService.currUser.userId).subscribe(
        (data) => {
          this.playlists = data;
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }

  playPlaylist(playlistId: any) {
    this.playlistDetailServ.getAllByPlaylistId(playlistId).subscribe(
      (data) => {
        this.details = data;

        // צור массив של Observables
        const songObservables = this.details.map((k) => {
          return this.songServ.getBySongId(k.songId);
        });

        //forkJoin כדי לחכות לכל הקריאות לשרת
        forkJoin(songObservables).subscribe(
          (songs) => {
            // כעת כל השירים התקבלו
            this.songs = songs;

            // עכשיו אפשר לקרוא ל-navigate כאן
            this.route.navigate(['player'], { state: { songs: this.songs } });
          },
          (err) => {
            console.log(err);
          }
        );
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
