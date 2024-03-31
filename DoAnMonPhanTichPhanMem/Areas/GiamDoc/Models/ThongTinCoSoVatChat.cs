namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class ThongTinCoSoVatChat
	{
		public int maThietBi { get; set; }
		public int maLoai { get; set; }
		public int maNhaCungCap { get; set; }
		public string? tenThietBi { get; set; }
		public string? hinhAnh { get; set; }
		public int soLuong { get; set; }
		public string? trangThai { get; set; }
		public string? thongSo { get; set; }
		public DateTime ngayNhap { get; set; }
		public LoaiCoSoVatChat loaiCoSoVatChat { get; set; }
		public NhaCungCap nhaCungCap { get; set; }
		public ICollection<DanhSachThietBi> danhSachThietBi { get; set; }
		public ICollection<ChiTietDonMuon> chiTietDonMuon { get; set; }
		public ICollection<ChiTietDonTra> chiTietDonTra { get; set; }
	}
}
