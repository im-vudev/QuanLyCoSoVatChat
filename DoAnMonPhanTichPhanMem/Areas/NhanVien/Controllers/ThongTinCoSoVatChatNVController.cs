using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
	[Area("NhanVien")]
	public class ThongTinCoSoVatChatNVController : Controller
	{
		private QuanLyCoSoVatChatContext context;
		public ThongTinCoSoVatChatNVController(QuanLyCoSoVatChatContext cc)
		{
			this.context = cc;
		}
        private bool CheckLogin()
        {
            if (HttpContext.Session.GetString("role") == "Nhân Viên")
            {
                return true;
            }
            return false;
        }
        [Route("NhanVien/[controller]/[action]")]
		public IActionResult Index(int? page)
		{
            if (CheckLogin())
            {
                int PageSize = 7;
                int Pagenumber = (page ?? 1);

                var AllData = context.thongTinCoSoVatChat.Include(L => L.loaiCoSoVatChat).Include(N => N.nhaCungCap).ToList();

                IPagedList<ThongTinCoSoVatChat> DataPage = AllData.ToPagedList(Pagenumber, PageSize);
                return View(DataPage);
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
		}
	}
}
