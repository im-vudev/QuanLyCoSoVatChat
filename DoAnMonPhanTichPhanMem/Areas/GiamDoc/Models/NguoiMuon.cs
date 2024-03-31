namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class NguoiMuon
	{
        public int maNguoiMuon { get; set; }
		public string? hoVaTen { get; set; }
		public string? soDienThoai { get; set; }
		public string? diaChi { get; set; }
		public DateTime ngayDangKy { get; set; }
		public ICollection<DonMuon> donMuon { get; set; }
        public ICollection<DonTra> donTra { get; set; }
    }
}
