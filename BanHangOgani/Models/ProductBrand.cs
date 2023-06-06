using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class ProductBrand
{
    public string BrandId { get; set; } = null!;

    public string? BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
