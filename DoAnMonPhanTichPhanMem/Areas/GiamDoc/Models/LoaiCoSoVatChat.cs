namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models
{
	public class LoaiCoSoVatChat
	{
		public int maLoai { get; set; }
		public string tenLoai { get; set; }

		public string moTa { get; set; }

		public ICollection<ThongTinCoSoVatChat> thongTinCoSoVatChat { get; set; }

	}
}
