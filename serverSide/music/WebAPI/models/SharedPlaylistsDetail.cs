using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class SharedPlaylistsDetail
{
    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public bool? IsActive { get; set; }

    public int SharedPlaylistsDetailsId { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
