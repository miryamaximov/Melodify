import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { SingerService } from '../services/singer.service';
import { Singer } from '../classes/Singer';
import { NgFor, NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { Song } from '../classes/Song';
import { SongService } from '../services/song.service';
import { max } from 'rxjs';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  hover: boolean = false;
  singer: Singer = new Singer();
  songs:Array<Song> = new Array<Song>()
  my_max:number = 0
  constructor(
    public userServ: UserService,
    public singerServ: SingerService,
    public songServ:SongService,
    public route: Router
  ) {
    singerServ.getAll().subscribe(
      (data) => {
        this.singer = data[Math.floor(Math.random() * data.length)];
      },
      (err) => {
        console.log(err);
      }
    );

    songServ.getAll().subscribe((data)=>{
     for (let index = 0; index < 5; index++) {
     this.songs.push(data[Math.floor(Math.random() * data.length)])
     } }, (err)=>{console.log(err);
    })
  }
  showMore() {
    this.route.navigate(['singer-details/' + this.singer.singerId]);
  }
}
