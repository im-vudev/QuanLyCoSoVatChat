namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class TaiKhoan
	{
		public int maTaKhoan { get; set; }
		public int maNguoiDung { get; set; }
		public string? hinhAnh { get; set; }
		public string? email { get; set; }
		public string? matKhau { get; set; }
		public Users users { get; set; }
	}
}
