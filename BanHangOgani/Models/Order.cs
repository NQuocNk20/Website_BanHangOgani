using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class Order
{
    public string OrderNo { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public decimal? TotalCost { get; set; }

    public string? CartId { get; set; }

    public string? SupplierId { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public string? Notes { get; set; }

    public string? Payments { get; set; }

    public string? DiscountCode { get; set; }

    public virtual ShoppingCart? Cart { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual OrderDetail OrderNoNavigation { get; set; } = null!;

    public virtual Supplier? Supplier { get; set; }
}
