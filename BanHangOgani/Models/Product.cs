using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public decimal? ProductPrice { get; set; }

    public byte[]? ImgPhoto { get; set; }

    public string? ProductDiscount { get; set; }

    public decimal? PorductRate { get; set; }

    public string? ProductImgPath { get; set; }

    public string? PorductVideo { get; set; }

    public string? CategoryId { get; set; }

    public string? BrandId { get; set; }

    public string? SupplierId { get; set; }

    public virtual ProductBrand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual Supplier? Supplier { get; set; }
}
