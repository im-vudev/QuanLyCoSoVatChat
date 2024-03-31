namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class ChiTietDonTra
	{
		public int maChiTietDonTra { get; set; }
		public int maDonTra { get; set; }
		public int maThietBi { get; set; }
		public int soLuongTra { get; set; }
		public string? tenThietBi { get; set; }
		public string? moTa { get; set; }

		public DonTra donTra { get; set; }
		public ThongTinCoSoVatChat thongTinCoSoVatChat { get; set; }

	}
}
