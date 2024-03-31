using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class PhongBanController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        public PhongBanController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
        {
            this.context = cc;
            this.toast = toast;
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

                var AllData = context.phongBan.Include(U => U.users).ToList();
                IPagedList<PhongBan> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> US = new List<SelectListItem>();
                US = context.users.Select(U => new SelectListItem { Text = U.tenNguoiDung, Value = U.maNguoiDung.ToString() }).ToList();
                ViewBag.Users = US;
                return View();
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Create(PhongBan PB)
        {
            context.Add(PB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Phòng Ban Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                PhongBan PB = await context.phongBan.Where(P => P.maPhongBan == id).FirstOrDefaultAsync();

                List<SelectListItem> US = new List<SelectListItem>();
                US = context.users.Select(U => new SelectListItem { Text = U.tenNguoiDung, Value = U.maNguoiDung.ToString() }).ToList();
                ViewBag.Users = US;
                return View(PB);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }
        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> update(PhongBan PB)
        {
            context.Update(PB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Phòng Ban Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var PB = new PhongBan() { maPhongBan = id };
            context.Remove(PB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Phòng Ban Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> DeleteAll()
        {
            var PB = context.phongBan.ToList();
            context.RemoveRange(PB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Tất Cả Phòng Ban Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }
    }
}
