using Microsoft.AspNetCore.Http.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebCTAoDai30.Repository.Validation;

namespace WebCTAoDai30.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public int? MaNcc { get; set; }

    public int? MaLsp { get; set; }

    public int? MaSize { get; set; }

    public string? TenSp { get; set; }

    public string? MoTaSp { get; set; }

    public decimal? Gia { get; set; }

    public decimal? GiaSale { get; set; }

    public DateTime? NgayNhapHang { get; set; }

    public string? HinhAnh { get; set; } = "noimage.jpg";

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual LoaiSp? MaLspNavigation { get; set; }

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual SizeSp? MaSizeNavigation { get; set; }

    internal object OrderByDescending(Func<object, object> value)
	{
		throw new NotImplementedException();
	}
    [NotMapped]
    [FileExtension]
    public IFormFile? ImageUpload { get; set; }
}
