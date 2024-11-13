import { Component } from '@angular/core';
import { Album } from '../classes/Album';
import { AlbumService } from '../services/album.service';
import { NgFor } from '@angular/common';
import { Router, RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-album-list',
  standalone: true,
  imports: [NgFor, RouterOutlet],
  templateUrl: './album-list.component.html',
  styleUrl: './album-list.component.css',
})
export class AlbumListComponent {
  albums: Album[] = new Array<Album>();

  constructor(public albumServ: AlbumService, public router:Router) {
    albumServ.getAll().subscribe(
      (data) => {
        this.albums = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  goToAlbumDetails(albumId:any){
    this.router.navigate(['albums/album-details/'+albumId])
  }
}
