export class Album {
  constructor(
    public albumId?: number,
    public albumName?: string,
    public albumSingerId?: number,
    public albumSingerFirstName?: string,
    public albumSingerLastName?: string,
    public publishingDate?: Date,
    public uploadDate?: Date,
    public imageUrl?: string
  ) {}
}
