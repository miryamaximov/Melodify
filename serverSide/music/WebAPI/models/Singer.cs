using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class Singer
{
    public int SingerId { get; set; }

    public string SingerFirstName { get; set; } = null!;

    public string? SingerLastName { get; set; }

    public string? ImageUrl { get; set; }

    public string? SingerAbout { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Follower> Followers { get; set; } = new List<Follower>();

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
