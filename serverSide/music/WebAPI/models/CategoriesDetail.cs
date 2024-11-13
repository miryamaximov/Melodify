using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class CategoriesDetail
{
    public int CategoryId { get; set; }

    public int SongId { get; set; }

    public int CategoriesDetailsId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
