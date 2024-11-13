import { Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { UserPlaylistsComponent } from './user-playlists/user-playlists.component';
import { UserPlaylistDetailsComponent } from './user-playlist-details/user-playlist-details.component';
import { ArtistListComponent } from './artist-list/artist-list.component';
import { ArtistDetailesComponent } from './artist-detailes/artist-detailes.component';
import { AlbumListComponent } from './album-list/album-list.component';
import { AlbumDetailesComponent } from './album-detailes/album-detailes.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryListDetailedComponent } from './category-list-detailed/category-list-detailed.component';
import { SongsListComponent } from './songs-list/songs-list.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { ContentManagementComponent } from './content-management/content-management.component';
import { SongPlayerComponent } from './song-player/song-player.component';
import { ProfileComponent } from './profile/profile.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HeaderComponent,
    children: [
      { path: 'home', component: HomeComponent }, //עמוד הבית
      { path: 'login', component: LoginComponent }, //התחברות
      { path: 'signup', component: SignupComponent }, //הרשמה
      {
        path: 'user-playlists',
        component: UserPlaylistsComponent,
        children: [
          {
            path: 'user-playlist-details',
            component: UserPlaylistDetailsComponent,
          },
        ],
      }, //רשימות השמעה של המשתמש
      {
        path: 'singers',
        component: ArtistListComponent,
      },
      { path: 'singer-details/:singerId', component: ArtistDetailesComponent }, //רשימת זמרים
      {
        path: 'albums',
        component: AlbumListComponent,
        children: [
          { path: 'album-details/:albumId', component: AlbumDetailesComponent },
        ],
      }, //רשימת אלבומים
      {
        path: 'categories',
        component: CategoryListComponent
        // children: [
        //   {
        //     path: 'category-details',
        //     component: CategoryListDetailedComponent,
        //   },
        // ],
      }, {
        path: 'category-details/:categoryId',
        component: CategoryListDetailedComponent,
      }, //רשימת קטגוריות
      { path: 'songs', component: SongsListComponent }, //רשימת שירים
      { path: 'manage-users', component: UserManagementComponent }, //ניהול משתמשים
      { path: 'manage-content', component: ContentManagementComponent }, //ניהול תוכן
      { path: 'profile', component: ProfileComponent }, //פרופיל
      {path: 'player', component: SongPlayerComponent},
      { path: '', redirectTo: 'home', pathMatch: 'full' }, // ברירת מחדל לעמוד הבית
    ],
  },
];
