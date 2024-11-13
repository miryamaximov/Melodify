using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } =null!;

    public string UserPass { get; set; } = null!;

    public string? UserEmail { get; set; }

    public bool  IsAdmin { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
