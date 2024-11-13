using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class Album
{
    public int AlbumId { get; set; }

    public string AlbumName { get; set; } = null!;

    public int AlbumSingerId { get; set; }

    public DateTime? PublishingDate { get; set; }

    public DateTime? UploadDate { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Singer AlbumSinger { get; set; } = null!;

    public virtual ICollection<AlbumsDetail> AlbumsDetails { get; set; } = new List<AlbumsDetail>();
}
