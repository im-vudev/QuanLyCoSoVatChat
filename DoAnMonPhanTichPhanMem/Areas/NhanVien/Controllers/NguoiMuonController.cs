using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using NToastNotify;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class NguoiMuonController : Controller
    {
        private readonly IToastNotification toast;
        private QuanLyCoSoVatChatContext context;
        public NguoiMuonController(QuanLyCoSoVatChatContext cc, IToastNotification toast)
        {
            this.context = cc;
            this.toast = toast;
        }
        private bool CheckLogin()
        {
            if (HttpContext.Session.GetString("role") == "Nhân Viên")
            {
                return true;
            }
            return false;
        }
        [Route("NhanVien/[controller]/[action]")]
        public IActionResult Index(int? page)
        {
            if (CheckLogin())
            {
                int PageSize = 7;
                int PageNumber = (page ?? 1);
                var AllData = context.nguoiMuon.ToList();
                IPagedList<NguoiMuon> DataPage = AllData.ToPagedList(PageNumber, PageSize);
                return View(DataPage);
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }

        [Route("NhanVien/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                return View();
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Create(NguoiMuon NM)
        {
            context.Add(NM);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Thêm Thành Công Người Mượn", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Update(int id)
        {
            if (CheckLogin())
            {
                NguoiMuon NM = await context.nguoiMuon.Where(e => e.maNguoiMuon == id).FirstOrDefaultAsync();
                return View(NM);
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Update(NguoiMuon NM)
        {
            context.Update(NM);
            await context.SaveChangesAsync();
            toast.AddSuccessToastMessage("Sửa Thành Công Người Mượn", new ToastrOptions { Title = "Thông Báo" });
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var NM = new NguoiMuon() { maNguoiMuon = id };
            context.Remove(NM);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public  async Task<IActionResult> DeleteAll()
        {
            var NM = context.nguoiMuon.ToList();
            context.RemoveRange(NM);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
