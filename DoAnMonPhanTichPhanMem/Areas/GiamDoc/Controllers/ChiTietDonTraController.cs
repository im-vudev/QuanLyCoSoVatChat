using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class ChiTietDonTraController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public ChiTietDonTraController(QuanLyCoSoVatChatContext cc)
        {
            context = cc;
        }
        private bool CheckLogin()
        {
            if (HttpContext.Session.GetString("role") == "Giám Đốc")
            {
                return true;
            }
            return false;
        }
        [Route("GiamDoc/[controller]/[action]")]
        public IActionResult Index(int? page)
        {
            if (CheckLogin())
            {
                int PageSize = 7;
                int PageNumber = (page ?? 1);
                var AllData = context.donTra.Include(U => U.users).Include(D => D.nguoiMuon).Include(C => C.chiTietDonTra).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
                IPagedList<DonTra> PageTra = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageTra);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }
    }
}
