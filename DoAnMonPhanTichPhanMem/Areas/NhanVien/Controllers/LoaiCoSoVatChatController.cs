using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class LoaiCoSoVatChatController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public LoaiCoSoVatChatController(QuanLyCoSoVatChatContext cc)
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
                int pageSize = 7;
                int pageNumber = (page ?? 1);

                var allData = context.loaiCoSoVatChat.ToList();
                IPagedList<LoaiCoSoVatChat> pageData = allData.ToPagedList(pageNumber, pageSize);
                return View(pageData);
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }
    }
}
