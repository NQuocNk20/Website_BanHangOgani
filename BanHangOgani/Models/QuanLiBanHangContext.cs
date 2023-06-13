using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BanHangOgani.Models;

public partial class QuanLiBanHangContext : DbContext
{
    public QuanLiBanHangContext()
    {
    }

    public QuanLiBanHangContext(DbContextOptions<QuanLiBanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-84NQEPG\\SQLEXPRESS;uid=sa;password=1;database=QuanLiBanHang;Encrypt=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Ncategory)
                .HasMaxLength(20)
                .HasColumnName("NCategory");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryName).HasMaxLength(25);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasColumnType("image");
            entity.Property(e => e.AnhDaiDienPath).HasMaxLength(255);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(50);
            entity.Property(e => e.NgaySinh)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_KhachHang_User");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasColumnType("image");
            entity.Property(e => e.AnhDienDienPath).HasMaxLength(255);
            entity.Property(e => e.ChucVu).HasMaxLength(25);
            entity.Property(e => e.NgaySinh)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Phone1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_NhanVien_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.Property(e => e.OrderNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CartId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiscountCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Payments).HasMaxLength(20);
            entity.Property(e => e.SupplierId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalCost).HasColumnType("money");

            entity.HasOne(d => d.Cart).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_Orders_ShoppingCart");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_Orders_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_Orders_NhanVien");

            entity.HasOne(d => d.OrderNoNavigation).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.OrderNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_OrderDetail");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Orders_Supplier");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Discount).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.ProductId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BrandId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ImgPhoto)
                .HasColumnType("image")
                .HasColumnName("imgPhoto");
            entity.Property(e => e.PorductRate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.PorductVideo).HasMaxLength(255);
            entity.Property(e => e.ProductDescription).HasMaxLength(255);
            entity.Property(e => e.ProductDiscount)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductImgPath).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Products_ProductBrand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Category");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Supplier");
        });

        modelBuilder.Entity<ProductBrand>(entity =>
        {
            entity.HasKey(e => e.BrandId);

            entity.ToTable("ProductBrand");

            entity.Property(e => e.BrandId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BrandName).HasMaxLength(255);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.CartId);

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CartId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ShoppingCart_Products");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SupAddress).HasMaxLength(50);
            entity.Property(e => e.SupEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupName).HasMaxLength(255);
            entity.Property(e => e.SupPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Supplier_Country");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserType).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
