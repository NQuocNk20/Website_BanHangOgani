using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string? Username { get; set; }

    public string? TenKhachHang { get; set; }

    public string? NgaySinh { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? LoaiKhachHang { get; set; }

    public byte[]? AnhDaiDien { get; set; }

    public string? AnhDaiDienPath { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? UsernameNavigation { get; set; }
}
