using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class PlaylistsDetail
{
    public int PlaylistsDetailsId { get; set; }

    public int PlaylistId { get; set; }

    public int SongId { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
