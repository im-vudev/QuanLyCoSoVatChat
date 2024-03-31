using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class ChiTietDonTraController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public ChiTietDonTraController(QuanLyCoSoVatChatContext cc)
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

        [Route("Nhanvien/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
