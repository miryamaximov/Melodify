using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int UserId { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? PlaylistName { get; set; }

    public bool IsActive { get; set; }
    public virtual User User { get; set; } = null!;

}
