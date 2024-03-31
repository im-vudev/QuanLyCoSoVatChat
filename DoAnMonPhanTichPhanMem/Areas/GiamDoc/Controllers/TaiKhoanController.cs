using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class TaiKhoanController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        public TaiKhoanController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
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

                var Data = context.taiKhoan.Include(T => T.users).ToList();
                IPagedList<TaiKhoan> Pagedata = Data.ToPagedList(PageNumber, PageSize);
                return View(Pagedata);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> US = new List<SelectListItem>();
                US = context.users.Select(U => new SelectListItem { Text = U.vaiTro, Value = U.maNguoiDung.ToString() }).ToList();
                ViewBag.users = US;
                return View();
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Create(TaiKhoan TK, IFormFile hinhAnh)
        {
            if (hinhAnh != null && hinhAnh.Length > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Admin/Upload");
                Directory.CreateDirectory(uploadPath);
                var fileName = Path.GetFileName(hinhAnh.FileName);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await hinhAnh.CopyToAsync(fileStream);
                }
                TK.hinhAnh = fileName;
                context.Add(TK);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Thêm Thành Công Tài Khoản", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                TaiKhoan TK = await context.taiKhoan.Where(T => T.maTaKhoan == id).AsNoTracking().FirstOrDefaultAsync();
                List<SelectListItem> US = new List<SelectListItem>();
                US = context.users.Select(U => new SelectListItem { Text = U.vaiTro, Value = U.maNguoiDung.ToString() }).ToList();
                ViewBag.Users = US;
                return View(TK);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(TaiKhoan TK ,int maTaKhoan, IFormFile hinhAnh)
        {
            TaiKhoan TKd = context.taiKhoan.Where(T => T.maTaKhoan == maTaKhoan).AsNoTracking().FirstOrDefault();
            if(TK != null)
            {
                if(hinhAnh != null && hinhAnh.Length > 0)
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Admin/Upload");
                    Directory.CreateDirectory(uploadPath);
                    var fileName = Path.GetFileName(hinhAnh.FileName);
                    var filePath = Path.Combine(uploadPath, fileName);

                    using (var fileStram = new FileStream(filePath, FileMode.Create))
                    {
                        await hinhAnh.CopyToAsync(fileStram);
                    }
                    TK.hinhAnh = fileName;
                }
                else
                {
                    TK.hinhAnh = TKd.hinhAnh;
                }
                context.Update(TKd).CurrentValues.SetValues(TK);
                context.SaveChanges();
                toast.AddSuccessToastMessage("Sửa Thành Công Tài Khoản", new ToastrOptions { Title = "Thông Báo" });

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var TK = new TaiKhoan() { maTaKhoan = id };
            context.Remove(TK);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Thành Công Tài Khoản", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> DeleteAll()
        {
            var TK = context.taiKhoan.ToList();
            context.RemoveRange(TK);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Tất Cả Tài Khoản Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }
    }
}
