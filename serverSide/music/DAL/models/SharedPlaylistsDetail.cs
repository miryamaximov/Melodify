using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class SharedPlaylistsDetail
{
    public int SharedPlaylistsDetailsId { get; set; }

    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public bool IsActive { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual User User { get; set; } = null!;

}
