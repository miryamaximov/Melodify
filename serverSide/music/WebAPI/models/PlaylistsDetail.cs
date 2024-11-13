using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class PlaylistsDetail
{
    public int PlaylistId { get; set; }

    public int SongId { get; set; }

    public int PlaylistsDetailsId { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
