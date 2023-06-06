using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class OrderDetail
{
    public string OrderNo { get; set; } = null!;

    public string? ProductId { get; set; }

    public decimal? ProductPrice { get; set; }

    public int Quantity { get; set; }

    public string? Notes { get; set; }

    public string? Discount { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
