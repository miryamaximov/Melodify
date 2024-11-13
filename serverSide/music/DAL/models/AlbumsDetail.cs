using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class AlbumsDetail
{
    public int AlbumsDetailsId { get; set; } 
    public int AlbumId { get; set; }

    public int SongId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
