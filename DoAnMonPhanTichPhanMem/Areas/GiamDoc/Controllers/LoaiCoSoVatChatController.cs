using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using NToastNotify;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class LoaiCoSoVatChatController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        private readonly IToastNotification toast;
        public LoaiCoSoVatChatController(QuanLyCoSoVatChatContext cc, IToastNotification tt)
        {
            this.context = cc;
            this.toast = tt;
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

                var allData = context.loaiCoSoVatChat.ToList();
                IPagedList<LoaiCoSoVatChat> pageData = allData.ToPagedList(pageNumber, pageSize);
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

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(LoaiCoSoVatChat LCSVC)
        {
            context.Add(LCSVC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Loại Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                LoaiCoSoVatChat LCSVC = await context.loaiCoSoVatChat.Where(e => e.maLoai == id).FirstOrDefaultAsync();
                return View(LCSVC);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Update(LoaiCoSoVatChat LCSVC)
        {
            context.Update(LCSVC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Loại Cơ Sở Vật Chất Thành Công", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var LCSVC = new LoaiCoSoVatChat() { maLoai = id };
                context.Remove(LCSVC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Loại Cơ Sở Vật Chất Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Xóa Loại Cơ Sở Vật Chất Không Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            return RedirectToAction("Index");
        }

        [Route("GiamDoc/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var LCSVC = context.loaiCoSoVatChat.ToList();

                context.RemoveRange(LCSVC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Tất Cả Loại Cơ Sở Vật Chất Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {
                toast.AddErrorToastMessage("Xóa Tất Cả Loại Cơ Sở Vật Chất Không Thành Công", new ToastrOptions { Title = "Thông Báo" });
            }
            
            return RedirectToAction("Index");
        }
    }
}
