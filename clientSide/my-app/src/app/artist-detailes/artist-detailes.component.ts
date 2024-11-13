import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SingerService } from '../services/singer.service';
import { Singer } from '../classes/Singer';

@Component({
  selector: 'app-artist-detailes',
  standalone: true,
  imports: [],
  templateUrl: './artist-detailes.component.html',
  styleUrl: './artist-detailes.component.css',
})
export class ArtistDetailesComponent {
  singer: Singer = new Singer();
  constructor(
    public activeRoute: ActivatedRoute,
    public singerServ: SingerService
  ) {
    activeRoute.params.subscribe((k: any) => {
      singerServ.getById(k['singerId']).subscribe(
        (data) => {
          this.singer = data;
        },
        (err) => {
          console.log(err);
        }
      );
    });
  }
}
