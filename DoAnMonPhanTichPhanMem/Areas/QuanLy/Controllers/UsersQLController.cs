using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class UsersQLController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public UsersQLController(QuanLyCoSoVatChatContext cc)
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
        public IActionResult Index()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }
    }
}
