using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class ShoppingCart
{
    public string CartId { get; set; } = null!;

    public string? ProductId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product? Product { get; set; }
}
