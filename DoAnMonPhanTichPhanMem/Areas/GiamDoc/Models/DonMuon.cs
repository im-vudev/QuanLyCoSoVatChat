namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class DonMuon
	{
		public int maDonMuon { get; set; }
		public int maNguoiDung { get; set; }
		public int maNguoiMuon { get; set; }
		public string? hoVaTen { get; set; }
		public string? soDienThoai { get; set; }
		public string? email { get; set; }
		public DateTime ngayMuon { get; set; }
        public string? mucDich { get; set; }
		public string? chucNang { get; set; }
		public Users users { get; set; }
		public NguoiMuon nguoiMuon { get; set; }
		public ICollection<ChiTietDonMuon> chiTietDonMuon { get; set; }
	}
}
