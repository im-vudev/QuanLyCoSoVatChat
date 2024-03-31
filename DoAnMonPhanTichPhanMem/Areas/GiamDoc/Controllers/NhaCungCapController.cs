using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class NhaCungCapController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        private readonly IToastNotification toast;
        public NhaCungCapController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
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
                int pageSize = 7;
                int pageNumber = (page ?? 1);

                var allData = context.nhaCungCap.ToList();
                var pageData = allData.ToPagedList(pageNumber, pageSize);
                return View(pageData);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }
        [HttpGet]
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
        public async Task<IActionResult> Create(NhaCungCap NCC)
        {
            context.Add(NCC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Nhà Cung Cấp Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                NhaCungCap NCC = await context.nhaCungCap.Where(e => e.maNhaCungCap == id).FirstOrDefaultAsync();
                return View(NCC);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Update(NhaCungCap NCC)
        {
           
            context.Update(NCC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Nhà Cung Cấp Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var NCC = new NhaCungCap() { maNhaCungCap = id };
                context.Remove(NCC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Nhà Cung Cấp Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Xóa Nhà Cung Cấp Không Thành công", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var NCC = context.nhaCungCap.ToList();

                context.RemoveRange(NCC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Tất Cả Nhà Cung Cấp Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Xóa Tất Cả Nhà Cung Cấp Không Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }
    }
}
