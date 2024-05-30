using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? TenDangNhap { get; set; } = null!;

    public string? MatKhau { get; set; } = null!;

    public string HoTen { get; set; } 

    public string GioiTinh { get; set; } = null!;

    public string? DiaChi { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? SoDt { get; set; } = null!;

    public bool? LaAdmin { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
