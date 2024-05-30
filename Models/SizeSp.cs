using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class SizeSp
{
    public int MaSize { get; set; }

    public string? TenSize { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
