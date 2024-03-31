using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using NToastNotify;
using X.PagedList.Mvc.Core;
using X.PagedList;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class LoaiCoSoVatChatController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        public LoaiCoSoVatChatController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
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
                int pageSize = 5;
                int pageNumber = (page ?? 1);

                var allData = context.loaiCoSoVatChat.ToList();
                var pageData = allData.ToPagedList(pageNumber, pageSize);
                return View(pageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(LoaiCoSoVatChat LCSVC)
        {
            context.Add(LCSVC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Loại Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                LoaiCoSoVatChat LCSVC = await context.loaiCoSoVatChat.Where(e => e.maLoai == id).FirstOrDefaultAsync();
                //await context.SaveChangesAsync();
                return View(LCSVC);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Update(LoaiCoSoVatChat LCSVC)
        {
            context.Update(LCSVC);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Thành Công Loại Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var LCSVC = new LoaiCoSoVatChat() { maLoai = id };
                context.Remove(LCSVC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Thành Công Loại Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {

                toast.AddErrorToastMessage("Không Thể Xóa Loại Cơ Sở Vật Chất này", new ToastrOptions { Title = "Thông Báo" });
            }
       
            return RedirectToAction("Index");
        }

        [Route("QuanLy/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var LCSVC = context.loaiCoSoVatChat.ToList();
                context.RemoveRange(LCSVC);
                await context.SaveChangesAsync();
                toast.AddSuccessToastMessage("Xóa Tất Cả Thành Công Loại Cơ Sở Vật Chất", new ToastrOptions { Title = "Thông Báo" });
            }
            catch (Exception)
            {

                toast.AddErrorToastMessage("Không Thể Xóa tất Cả", new ToastrOptions { Title = "Thông Báo" });
            }
     
            return RedirectToAction("Index");
        }
    }
}
