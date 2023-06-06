using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string? SupName { get; set; }

    public string? SupEmail { get; set; }

    public string? SupPhone { get; set; }

    public string? SupAddress { get; set; }

    public string? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
