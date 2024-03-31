using Microsoft.AspNetCore.Mvc;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class UsersNVController : Controller
    {
        private bool CheckLogin()
        {
            if (HttpContext.Session.GetString("role") == "Nhân Viên")
            {
                return true;
            }
            return false;
        }
        [Route("NhanVien/[controller]/[action]")]
        public IActionResult Index()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }
    }
}
