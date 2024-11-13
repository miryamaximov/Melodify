using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Follower
{
    public int FollowerId { get; set; }
    public int SingerId { get; set; }

    public int UserId { get; set; }

    public virtual Singer Singer { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
