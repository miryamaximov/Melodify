using System;
using System.Collections.Generic;

namespace WebAPI.models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<CategoriesDetail> CategoriesDetails { get; set; } = new List<CategoriesDetail>();
}
