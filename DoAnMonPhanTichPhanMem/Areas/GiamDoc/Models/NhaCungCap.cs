namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class NhaCungCap
	{
		public int maNhaCungCap { get; set; }
		public string? tenNhaCungCap { get; set; }
		public string? diaChi { get; set; }
		public string? soDienThoai { get; set; }
		public string? email { get; set; }

		public ICollection<ThongTinCoSoVatChat> thongTinCoSoVatChat { get; set; }

	}
}
