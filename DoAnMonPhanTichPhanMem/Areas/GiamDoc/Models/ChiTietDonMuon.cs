namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class ChiTietDonMuon
	{
		public int maChiTietDonMuon { get; set; }
		public int maDonMuon { get; set; }
		public int maThietBi { get; set; }
		public int soLuongMuon { get; set; }
		public DateTime ngayTraDuKien { get; set; }
		public DateTime ngayTraThucTe { get; set; }
		public string? trangThai { get; set; }

		public DonMuon donMuon { get; set; }
		public ThongTinCoSoVatChat thongTinCoSoVatChat { get; set; }
	}
}
