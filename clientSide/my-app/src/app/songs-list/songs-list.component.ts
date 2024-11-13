import { NgFor, NgIf } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { SongService } from '../services/song.service';
import { Song } from '../classes/Song';
import { Target } from '@angular/compiler';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { FormsModule } from '@angular/forms';
import { Playlist } from '../classes/Playlist';
import { PlaylistService } from '../services/playlist.service';
import { PlaylistDetailService } from '../services/playlist-detail.service';
import { PlaylistDetail } from '../classes/PlaylistDetail';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-songs-list',
  standalone: true,
  imports: [NgFor, FormsModule, NgIf],
  templateUrl: './songs-list.component.html',
  styleUrl: './songs-list.component.css',
})
export class SongsListComponent {
  songs: Array<Song> = new Array<Song>(); //מערך כל השירים שבתצוגה

  selectedSongId: Array<number> = new Array<number>(); //מערך הקודים של השירים שנבחרו
  selectedSong: Array<Song | undefined> = new Array<Song>(); //מערך השירים שנבחרו

  //התכונות שיעזרו ליצירת פלייליסט
  playlistName: string = '';
  playlist: Playlist = new Playlist();

  showScrollButton: boolean = false;


  constructor(
    public songService: SongService,
    public route: Router,
    public userService: UserService,
    public playlistService: PlaylistService,
    public playlistDetailService: PlaylistDetailService
  ) {
    songService.getAll().subscribe(
      (data) => {
        this.songs = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  addLikeToSong(songId: any) {
    let oldSong: any = this.songs.find((k) => k.songId == songId);
    let newSong = Object.assign({}, oldSong);
    newSong.likeNum = newSong.likeNum + 1;
    newSong.updateDate = new Date();

    this.songService.update(newSong).subscribe(
      (data) => {
        this.songs = data;
        console.log('The song has been successfully updated');
      },
      (err) => {
        console.log(err);
      }
    );
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showScrollButton = window.pageYOffset > 300;
  }

  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  toggleSongSelection(songId: any, event: Event) {
    const isChecked = (event.target as HTMLInputElement).checked;
    if (isChecked) {
      this.selectedSongId.push(songId);
    } else {
      this.selectedSongId.filter((id) => id !== songId);
    }
  }

  // A function that fills the array of selected songs according to the array of selected song codes
  private completeArraySelectedSong() {
    this.selectedSongId.forEach((k) => {
      this.selectedSong.push(this.songs.find((l) => l.songId == k));
    });
  }

  // send the selected song to player and play them
  playSelectedSong() {
    this.completeArraySelectedSong();
    this.route.navigate(['player'], { state: { songs: this.selectedSong } });
    this.resetSelection();
  }

  // create playlist from the selected song ang go to the playlists list
  createPlaylist() {
    if (!this.userService.isConnect) {
      alert('You need to login before creating a playlist');
      this.route.navigate(['/login']);
      return;
    }

    //create playlist
    this.playlist.playlistName = this.playlistName;
    this.playlist.updateDate = new Date();
    this.playlist.productionDate = new Date();
    this.playlist.userId = this.userService.currUser.userId;
    this.playlist.userName = this.userService.currUser.userName;

    this.completeArraySelectedSong(); //מילוי מערך השירים הנבחרים

    // לא לשכוח להוסיף ולדיציה על השדה של שם הפלייליסט שלא יהיה יותר ארוך מ20
    //קריאה להוספת הפלייליסט לשרת
    this.playlistService.add(this.playlist).subscribe(
      async (data) => {
        console.log(data, 'playlist list');
        this.playlist = data[data.length - 1];
        if (this.playlist && this.playlist.playlistId) {
          // הוספת כל השירים לפלייליסט
          for (const song of this.selectedSong) {
            await this.addSongToPlaylist(song?.songId, song?.songName);
          }
        }
      },
      (err) => {
        console.log(err);
      }
    );

    //  this.resetSelection()
  }

  addSongToPlaylist(songId: any, songName: any): Promise<any> {
    return new Promise((resolve, reject) => {
      const detail: PlaylistDetail = {
        playlistId: this.playlist.playlistId,
        playlistName: this.playlist.playlistName,
        songId: songId,
        songName: songName,
      };
      this.playlistDetailService.add(detail).subscribe(
        (data) => {
          console.log(data, 'songs list in the new playlist');
          resolve(data); // פותר את ההבטחה בהצלחה
        },
        (err) => {
          console.log(err);
          reject(err); // דוחה את ההבטחה בשגיאה
        }
      );
    });
  }

  //פונקציה לאיפוס המערכים
  private resetSelection() {
    this.selectedSong = [];
    this.selectedSongId = [];
    this.playlistName = '';
  }
}
