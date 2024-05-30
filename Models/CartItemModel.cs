namespace WebCTAoDai30.Models
{
	public class CartItemModel
	{
		public int MaSp { get; set; }
		public string? TenSp { get; set; }
		public int? SoLuong { get; set; }
		public decimal? GiaSale { get; set; }
		public decimal? Total
		{
			get { return GiaSale * SoLuong; }
		}
		public string HinhAnh { get; set; }
		public CartItemModel()
		{

		}
		public CartItemModel(SanPham sanPham)
		{
            MaSp = sanPham.MaSp;
            TenSp = sanPham.TenSp;
			GiaSale = sanPham.GiaSale;
			SoLuong = 1;
			HinhAnh = sanPham.HinhAnh;
		}
	}
}

