import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Song } from '../classes/Song';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-song-player',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './song-player.component.html',
  styleUrl: './song-player.component.css',
})
export class SongPlayerComponent {
  public songs: Array<Song> = new Array<Song>();
  public currentSongIndex: number = 0;
  private audio: HTMLAudioElement;
  public isPlaying: boolean = false;
  public volume: number = 0.5;

  constructor(public activeRouter: ActivatedRoute, public route: Router) {
    const navigation = route.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.songs = navigation.extras.state['songs'];
    }

    this.audio = new Audio();
    this.audio.src =
      '../../assets/songs/' + this.songs[this.currentSongIndex].songUrl;
    this.audio.volume = this.volume;
     this.audio.play()  //על מנת שהשיר יופעל מיד כשנכנסים
  }

  playSong(index: number): void {
    this.currentSongIndex = index;
    this.audio.src =
      '../../assets/songs/' + this.songs[this.currentSongIndex].songUrl;
    this.audio.play();
  }

  nextSong(): void {
    this.currentSongIndex = (this.currentSongIndex + 1) % this.songs.length;
    this.playSong(this.currentSongIndex);
  }

  previousSong(): void {
    this.currentSongIndex =
      (this.currentSongIndex - 1 + this.songs.length) % this.songs.length;
    this.playSong(this.currentSongIndex);
  }

  pauseSong(): void {
    if (this.isPlaying) {
      this.audio.pause();
    } else {
      this.audio.play();
    }
    this.isPlaying = !this.isPlaying;
  }

  increaseVolume() {
    if (this.volume < 1) {
      this.volume += 0.1;
      this.audio.volume = this.volume;
    }
  }
  decreaseVolume() {
    if (this.volume > 0) {
      this.volume -= 0.1;
      this.audio.volume = this.volume;
    }
  }
}
