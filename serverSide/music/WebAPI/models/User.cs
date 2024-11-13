using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPass { get; set; } = null!;

    public string? UserEmail { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<Follower> Followers { get; set; } = new List<Follower>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    public virtual ICollection<SharedPlaylistsDetail> SharedPlaylistsDetails { get; set; } = new List<SharedPlaylistsDetail>();
}
