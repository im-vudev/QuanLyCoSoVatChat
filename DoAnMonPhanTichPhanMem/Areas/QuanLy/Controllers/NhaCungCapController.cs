using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class NhaCungCapController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        public NhaCungCapController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
        {
            this.context = cc;
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

                var allData = context.nhaCungCap.ToList();
                var pageData = allData.ToPagedList(pageNumber, pageSize);
                return View(pageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }
        [HttpGet]
        [Route("QuanLy/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> Create(NhaCungCap NCC)
        {
            context.Add(NCC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Nhà Cung Cấp", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                NhaCungCap NCC = await context.nhaCungCap.Where(e => e.maNhaCungCap == id).FirstOrDefaultAsync();
                return View(NCC);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Update(NhaCungCap NCC)
        {

            context.Update(NCC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Thành Công Nhà Cung Cấp", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var NCC = new NhaCungCap() { maNhaCungCap = id };
                context.Remove(NCC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Thành Công Nhà Cung Cấp", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {

                toast.AddErrorToastMessage("Xóa Không Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var NCC = context.nhaCungCap.ToList();

                context.RemoveRange(NCC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Tất cả Thành Công Nhà Cung Cấp", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {

                toast.AddErrorToastMessage("Xóa Tất cả Không Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            
            return RedirectToAction("Index");
        }
    }
}
