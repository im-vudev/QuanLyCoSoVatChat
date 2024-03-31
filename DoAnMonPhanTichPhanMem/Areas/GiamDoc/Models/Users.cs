namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class Users
	{
		public int maNguoiDung { get; set; }
		public string? tenNguoiDung { get; set; }
        public string? gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string? CMND_CCCD { get; set; }
        public string? vaiTro { get; set; }
		public string? diaChi { get; set; }
		public string? soDienThoai { get; set; }
		public string? email { get; set; }
		public ICollection<TaiKhoan> taiKhoan { get; set; }
		public ICollection<PhongBan> phongBan { get; set; }
		public ICollection<DonMuon> donMuon { get; set; }
		public ICollection<DonTra> donTra { get; set; }
	}
}
