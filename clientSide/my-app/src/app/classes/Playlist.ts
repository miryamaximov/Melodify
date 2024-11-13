export class Playlist {
  constructor(
    public playlistId?: number,
    public playlistName?: string,
    public userId?: number,
    public productionDate?: Date,
    public updateDate?: Date,
    public userName?: string
  ) {}
}
