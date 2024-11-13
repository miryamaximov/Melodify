import { NonNullableFormBuilder } from '@angular/forms';

export class Song {
  constructor(
    public songId?: number,
    public songName?: string,
    public singerId?: number,
    public singerFirstName?: string,
    public singerLastName?: string,
    public publishingDate?: Date,
    public uploadDate?: Date,
    public songUrl: string = '',
    public imageUrl?: string,
    public songAbout?: string,
    public likeNum: number = 0
  ) {}
}
