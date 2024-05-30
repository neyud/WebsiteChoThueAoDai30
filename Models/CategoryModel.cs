using System.ComponentModel.DataAnnotations;
namespace WebCTAoDai30.Models
{
	public class CategoryModel
	{
		[Key]
		public int MaLsp { get; set; }
		[Required(ErrorMessage ="Yêu cầu nhập")]
		public string? TenLsp { get; set; }
		[Required(ErrorMessage = "Yêu cầu nhập")]
		public string? MoTa { get; set; }
	}
}
