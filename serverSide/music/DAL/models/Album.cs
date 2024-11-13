using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Album
{
    public int AlbumId { get; set; }

    public string AlbumName { get; set; } = null!;

    public int AlbumSingerId { get; set; }

    public DateTime? PublishingDate { get; set; }

    public DateTime? UploadDate { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Singer AlbumSingerNavigation { get; set; } = null!;
}
