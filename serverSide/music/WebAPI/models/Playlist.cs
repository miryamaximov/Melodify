using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? PlaylistName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PlaylistsDetail> PlaylistsDetails { get; set; } = new List<PlaylistsDetail>();

    public virtual ICollection<SharedPlaylistsDetail> SharedPlaylistsDetails { get; set; } = new List<SharedPlaylistsDetail>();

    public virtual User User { get; set; } = null!;
}
