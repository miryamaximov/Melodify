import { Component } from '@angular/core';
import { AlbumsDetail } from '../classes/AlbumsDetail';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumsDetailService } from '../services/albums-detail.service';
import { NgFor } from '@angular/common';
import { Song } from '../classes/Song';
import { SongService } from '../services/song.service';
import { state } from '@angular/animations';

@Component({
  selector: 'app-album-detailes',
  standalone: true,
  imports: [NgFor],
  templateUrl: './album-detailes.component.html',
  styleUrl: './album-detailes.component.css',
})
export class AlbumDetailesComponent {
  albumDetails: AlbumsDetail[] = new Array<AlbumsDetail>();
  songs: Array<Song> = new Array<Song>();
  constructor(
    public activeRouter: ActivatedRoute,
    public detaildServ: AlbumsDetailService,
    public songServ: SongService,
    public route: Router
  ) {
    this.activeRouter.params.subscribe((k: any) => {
      detaildServ.getAllByAlbumId(k['albumId']).subscribe(
        (data) => {
          this.albumDetails = data;
          for (let index = 0; index < this.albumDetails.length; index++) {
            songServ.getBySongId(this.albumDetails[index].songId).subscribe(
              (data) => {
                this.songs[index] = data;
              },
              (err) => {
                console.log(err);
              }
            );
          }
        },
        (err) => {
          console.log(err);
        }
      );
    });
  }
  goToPlayer() {
    this.route.navigate(['player'], { state: { songs: this.songs } });
    this.songs = new Array<Song>();
  }
}
