using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string? TenNhanVien { get; set; }

    public string? Sdt { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
