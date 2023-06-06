using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string? Ncategory { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
