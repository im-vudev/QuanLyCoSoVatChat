using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers;
using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class ThongTinCoSoVatChatQLController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        private readonly ILogger<ThongTinCoSoVatChatGDController> _logger;
        public ThongTinCoSoVatChatQLController(QuanLyCoSoVatChatContext cc, ILogger<ThongTinCoSoVatChatGDController> logger, IToastNotification toast)
        {
            this.context = cc;
            this._logger = logger;
            this.toast = toast;
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
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var data = context.thongTinCoSoVatChat.Include(L => L.loaiCoSoVatChat).Include(N => N.nhaCungCap).ToList();

                IPagedList<ThongTinCoSoVatChat> pagedData = data.ToPagedList(pageNumber, pageSize);

                return View(pagedData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");

        }

        [Route("QuanLy/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> LCSVC = new List<SelectListItem>();
                List<SelectListItem> NCC = new List<SelectListItem>();
                LCSVC = context.loaiCoSoVatChat.Select(L => new SelectListItem { Text = L.tenLoai, Value = L.maLoai.ToString() }).ToList();
                NCC = context.nhaCungCap.Select(N => new SelectListItem { Text = N.tenNhaCungCap, Value = N.maNhaCungCap.ToString() }).ToList();
                ViewBag.LoaiCoSoVatChat = LCSVC;
                ViewBag.NhaCungCap = NCC;

                return View();
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
		[Route("QuanLy/[controller]/[action]")]
		public async Task<IActionResult> Create(ThongTinCoSoVatChat THCSVC,IFormFile hinhAnh)
        {
            if (hinhAnh != null && hinhAnh.Length > 0)
            {
               
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Admin/Upload");
                Directory.CreateDirectory(uploadPath);
                var fileName = Path.GetFileName(hinhAnh.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await hinhAnh.CopyToAsync(fileStream);
                }
                THCSVC.hinhAnh = fileName;
                context.Add(THCSVC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Thêm Thành Công Thông Tin Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            }

            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                ThongTinCoSoVatChat TTCSVC = await context.thongTinCoSoVatChat.Where(T => T.maThietBi == id).AsNoTracking().FirstOrDefaultAsync();
                ViewBag.hinh = TTCSVC.hinhAnh;
                List<SelectListItem> LCSVC = new List<SelectListItem>();
                List<SelectListItem> NCC = new List<SelectListItem>();
                LCSVC = context.loaiCoSoVatChat.Select(L => new SelectListItem { Text = L.tenLoai, Value = L.maLoai.ToString() }).ToList();
                NCC = context.nhaCungCap.Select(N => new SelectListItem { Text = N.tenNhaCungCap, Value = N.maNhaCungCap.ToString() }).ToList();
                ViewBag.LoaiCoSoVatChat = LCSVC;
                ViewBag.NhaCungCap = NCC;
                return View(TTCSVC);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> Update(ThongTinCoSoVatChat thongTinCoSoVatChat,int maThietBi, IFormFile hinhAnh)
        {
            ThongTinCoSoVatChat TTCSVC = context.thongTinCoSoVatChat.Where(T => T.maThietBi == maThietBi).FirstOrDefault();
            if(TTCSVC != null)
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
                    thongTinCoSoVatChat.hinhAnh = fileName;

                }
                else
                {
                    thongTinCoSoVatChat.hinhAnh = TTCSVC.hinhAnh;
                }
                context.Update(TTCSVC).CurrentValues.SetValues(thongTinCoSoVatChat);
                context.SaveChanges();
                toast.AddSuccessToastMessage("Sửa Thành Công Thông Tin Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var TTCSVC = new ThongTinCoSoVatChat() { maThietBi = id };
            context.Remove(TTCSVC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Xóa Thành Công Thông Tin Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }
    }
}
