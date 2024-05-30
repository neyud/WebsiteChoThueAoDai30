using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebCTAoDai30.Models;

public partial class CtaoDaiContext : DbContext
{
    public CtaoDaiContext()
    {
    }

    public CtaoDaiContext(DbContextOptions<CtaoDaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<ChucNang> ChucNangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SizeSp> SizeSps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=f;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp }).HasName("PK_ChiTietHD_1");

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaHd)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaHD");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHD_HoaDon");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHD_SanPham");
        });

        modelBuilder.Entity<ChucNang>(entity =>
        {
            entity.HasKey(e => e.MaChucNang);

            entity.ToTable("ChucNang");

            entity.Property(e => e.TenChucNang).HasMaxLength(2000);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd);

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(200);
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.NgayGiaoHang).HasColumnType("datetime");
            entity.Property(e => e.NgayLapHd)
                .HasColumnType("datetime")
                .HasColumnName("NgayLapHD");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_HoaDon_KhachHang");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.SoDt)
                .HasMaxLength(11)
                .HasColumnName("SoDT");
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLsp);

            entity.ToTable("LoaiSP");

            entity.Property(e => e.MaLsp).HasColumnName("MaLSP");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenLsp)
                .HasMaxLength(200)
                .HasColumnName("TenLSP");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(4000);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.TenNcc)
                .HasMaxLength(500)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(2000);
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(1000);
            entity.Property(e => e.Username)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.MaChucNang });

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.GhiChu).HasMaxLength(2000);

            entity.HasOne(d => d.MaChucNangNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.MaChucNang)
                .HasConstraintName("FK_PhanQuyen_ChucNang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_PhanQuyen_NhanVien");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GiaSale).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhAnh).HasMaxLength(250);
            entity.Property(e => e.MaLsp).HasColumnName("MaLSP");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MoTaSp)
                .HasMaxLength(4000)
                .HasColumnName("MoTaSP");
            entity.Property(e => e.NgayNhapHang).HasColumnType("datetime");
            entity.Property(e => e.TenSp)
                .HasMaxLength(250)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLspNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLsp)
                .HasConstraintName("FK_SanPham_LoaiSP");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_SanPham_NhaCungCap");

            entity.HasOne(d => d.MaSizeNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaSize)
                .HasConstraintName("FK_SanPham_SizeSP");
        });

        modelBuilder.Entity<SizeSp>(entity =>
        {
            entity.HasKey(e => e.MaSize).HasName("PK_Size");

            entity.ToTable("SizeSP");

            entity.Property(e => e.TenSize).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
