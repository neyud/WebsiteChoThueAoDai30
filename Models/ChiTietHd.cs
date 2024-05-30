using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class ChiTietHd
{
    public int MaHd { get; set; }

    public int MaSp { get; set; }

    public int? MaSize { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
