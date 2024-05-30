using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public DateTime? NgayLapHd { get; set; }

    public DateTime? NgayGiaoHang { get; set; }

    public int? MaKh { get; set; }

    public string? DiaChiGiaoHang { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTraHang { get; set; }
    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual KhachHang? MaKhNavigation { get; set; }
}
