using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
