using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Song
{
    public int SongId { get; set; }

    public string SongName { get; set; } = null!;

    public int SingerId { get; set; }

    public DateTime? PublishingDate { get; set; }

    public DateTime? UploadDate { get; set; }

    public string SongUrl { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? SongAbout { get; set; }

    public int? LikeNum { get; set; }

    public virtual Singer Singer { get; set; } = null!;
}
