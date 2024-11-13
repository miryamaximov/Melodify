import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AlbumService } from './services/album.service';
import { AlbumsDetailService } from './services/albums-detail.service';
import { CategoriesDetailService } from './services/categories-detail.service';
import { CategoryService } from './services/category.service';
import { FollowerService } from './services/follower.service';
import { PlaylistDetailService } from './services/playlist-detail.service';
import { PlaylistService } from './services/playlist.service';
import { SharedPlaylistsDetailService } from './services/shared-playlists-detail.service';
import { SingerService } from './services/singer.service';
import { SongService } from './services/song.service';
import { UserService } from './services/user.service';
import { ArtistListComponent } from './artist-list/artist-list.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, HeaderComponent],
  providers: [
    AlbumService,
    AlbumsDetailService,
    CategoriesDetailService,
    CategoryService,
    FollowerService,
    PlaylistDetailService,
    PlaylistService,
    SharedPlaylistsDetailService,
    SingerService,
    SongService,
    UserService,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'my-app';
}
