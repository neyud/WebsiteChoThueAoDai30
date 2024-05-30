using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class PhanQuyen
{
    public int MaNv { get; set; }

    public int MaChucNang { get; set; }

    public string? GhiChu { get; set; }

    public virtual ChucNang MaChucNangNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
