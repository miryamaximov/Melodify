using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class AlbumsDetail
{
    public int AlbumId { get; set; }

    public int SongId { get; set; }

    public int AlbumsDetailsId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
