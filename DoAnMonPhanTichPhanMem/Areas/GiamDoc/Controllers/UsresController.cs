using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class UsresController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        private readonly ILogger<UsresController> _logger;
        public UsresController(QuanLyCoSoVatChatContext cc, ILogger<UsresController> logger, IToastNotification toast)
        {
            this.toast = toast;
            this.context = cc;
            _logger = logger;
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

                var alldata = context.users.ToList();
                IPagedList<Users> PageData = alldata.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Create(Users US)
        {
            context.Add(US);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Users", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                Users US = await context.users.Where(U => U.maNguoiDung == id).FirstOrDefaultAsync();
                return View(US);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(Users US)
        {
            context.Update(US);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Thành Công Users", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var US = new Users() { maNguoiDung = id };
                context.Remove(US);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Thành Công Users", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Users Đã Có Tài Khoản Không Thể Xóa", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> DeleteAll(int id)
        {
            try
            {
                var US = context.users.ToList();
                context.RemoveRange(US);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Tất Cả Users Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Users Đã Có Tài Khoản Không Thể Xóa tất cả", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }
    }
}
