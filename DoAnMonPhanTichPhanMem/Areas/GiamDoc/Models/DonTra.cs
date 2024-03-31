namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class DonTra
	{
		public int maDonTra { get; set; }
		public int maNguoiMuon { get; set; }
		public int maNguoiDung { get; set; }
		public string? hoVaTen { get; set; }
		public string? soDienThoai { get; set; }

		public string? email { get; set; }
		public DateTime ngayTra { get; set; }

		public string? trangThai { get; set; }
        public string? chucNang { get; set; }
        public Users users { get; set; }	
		public NguoiMuon nguoiMuon { get; set; }
		public ICollection<ChiTietDonTra> chiTietDonTra { get; set; }
	}
}
