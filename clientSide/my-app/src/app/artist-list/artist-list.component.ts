import { Component } from '@angular/core';
import { SingerService } from '../services/singer.service';
import { Singer } from '../classes/Singer';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artist-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './artist-list.component.html',
  styleUrl: './artist-list.component.css',
})
export class ArtistListComponent {
  singers: Array<Singer> = new Array<Singer>();
  constructor(public singerServ: SingerService, public router: Router) {
    this.singerServ.getAll().subscribe(
      (data) => {
        this.singers = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  goToDetails(singerId: any) {
    console.log(singerId);
    this.router.navigate(['singer-details/' + singerId]);
  }
}
