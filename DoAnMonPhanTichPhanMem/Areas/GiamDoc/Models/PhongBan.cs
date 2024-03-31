namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class PhongBan
	{
		public int maPhongBan { get; set; }
		public int maNguoiDung { get; set; }
		public string? tenPhongBan { get; set; }

		public Users users { get; set; }

		public ICollection<DanhSachThietBi> danhSachThietBi { get; set; }
	}
}
