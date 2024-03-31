namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class DanhSachThietBi
	{
		public int maDanhSachThietBi { get; set; }
		public int maPhongBan { get; set; }
		public int maThietBi { get; set; }
        public string? viTri { get; set; }
        public PhongBan phongBan { get; set; }
		public ThongTinCoSoVatChat thongTinCoSoVatChat { get; set; }

	}
}
