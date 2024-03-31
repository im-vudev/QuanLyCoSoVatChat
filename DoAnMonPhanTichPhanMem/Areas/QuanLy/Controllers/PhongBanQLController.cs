using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class PhongBanQLController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public PhongBanQLController(QuanLyCoSoVatChatContext cc)
        {
            this.context = cc;
        }
        private bool CheckLogin()
        {
            if (HttpContext.Session.GetString("role") == "Quản Lý")
            {
                return true;
            }
            return false;
        }
        [Route("QuanLy/[controller]/[action]")]
        public IActionResult Index(int? page)
        {
            if (CheckLogin())
            {
                int PageSize = 7;
                int PageNumber = (page ?? 1);
                var AllData = context.phongBan.Include(U => U.users).ToList();
                IPagedList<PhongBan> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }   
    }
}
