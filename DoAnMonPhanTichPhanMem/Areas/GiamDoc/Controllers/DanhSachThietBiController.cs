using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class DanhSachThietBiController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        private readonly IToastNotification toast;
        public DanhSachThietBiController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
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
                var AllData = context.danhSachThietBi.Include(P => P.phongBan).Include(T => T.thongTinCoSoVatChat).ToList();
                IPagedList<DanhSachThietBi> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> PB = new List<SelectListItem>();
                List<SelectListItem> TTCSVC = new List<SelectListItem>();
                List<SelectListItem> TT = new List<SelectListItem>();
                PB = context.phongBan.Select(P => new SelectListItem { Text = P.tenPhongBan, Value = P.maPhongBan.ToString() }).ToList();
                TTCSVC = context.thongTinCoSoVatChat.Select(T => new SelectListItem { Text = T.tenThietBi, Value = T.maThietBi.ToString() }).ToList();
                TT = context.thongTinCoSoVatChat.Select(S => new SelectListItem { Text = S.soLuong.ToString(), Value = S.maThietBi.ToString() }).ToList();
                ViewBag.PhongBan = PB;
                ViewBag.ThongTinCoSoVatChat = TTCSVC;
                ViewBag.TinCoSoVatChat = TT;
                return View();
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Create(DanhSachThietBi DSTB)
        {
            context.Add(DSTB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Danh Sách Thiết Bị", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                DanhSachThietBi DSTB = await context.danhSachThietBi.Where(D => D.maDanhSachThietBi == id).FirstOrDefaultAsync();
                List<SelectListItem> PB = new List<SelectListItem>();
                List<SelectListItem> TTCSVC = new List<SelectListItem>();
                List<SelectListItem> TT = new List<SelectListItem>();
                PB = context.phongBan.Select(P => new SelectListItem { Text = P.tenPhongBan, Value = P.maPhongBan.ToString() }).ToList();
                TTCSVC = context.thongTinCoSoVatChat.Select(T => new SelectListItem { Text = T.tenThietBi, Value = T.maThietBi.ToString() }).ToList();
                TT = context.thongTinCoSoVatChat.Select(T => new SelectListItem { Text = T.soLuong.ToString(), Value = T.maThietBi.ToString() }).ToList();
                ViewBag.PhongBan = PB;
                ViewBag.ThongTinCoSoVatChat = TTCSVC;
                ViewBag.TinCoSoVatChat = TT;
                return View(DSTB);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(DanhSachThietBi DSTB)
        {
            context.Update(DSTB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Danh Sách Thiết Bị Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var DSTB = new DanhSachThietBi() { maDanhSachThietBi = id };
            context.Remove(DSTB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Danh Sách Thiết Bị Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");   
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> DeleteAll()
        {
            var DSTB = context.danhSachThietBi.ToList();
            context.RemoveRange(DSTB);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Tất Cả Danh Sách Thiết Bị Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }
    }
}
