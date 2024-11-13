export class User {
  constructor(
    public userId?: number,
    public userName?: string,
    public userPass?: string,
    public userEmail?: string,
    public isAdmin?: boolean,
    public numOfPlaylists?: number
  ) {}
}
