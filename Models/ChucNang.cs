using System;
using System.Collections.Generic;

namespace WebCTAoDai30.Models;

public partial class ChucNang
{
    public int MaChucNang { get; set; }

    public string? TenChucNang { get; set; }

    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
