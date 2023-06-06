using System;
using System.Collections.Generic;

namespace BanHangOgani.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? Username { get; set; }

    public string? TenNhanVien { get; set; }

    public string? NgaySinh { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Address { get; set; }

    public string? ChucVu { get; set; }

    public byte[]? AnhDaiDien { get; set; }

    public string? AnhDienDienPath { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? UsernameNavigation { get; set; }
}
