using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class LoaiSp
{
    public int? MaLsp { get; set; }

    public string? TenLsp { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
