using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class CSVCDangMuonController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public CSVCDangMuonController(QuanLyCoSoVatChatContext cc)
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
            if(CheckLogin())
            {
                int PageSize = 5;
                int PageNumber = (page ?? 1);

                var allData = context.chiTietDonMuon.ToList();
                var pageData = allData.ToPagedList(PageSize, PageNumber);
                return View(pageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }
    }
}
