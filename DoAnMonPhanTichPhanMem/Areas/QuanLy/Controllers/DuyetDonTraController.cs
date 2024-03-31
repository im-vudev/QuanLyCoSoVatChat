using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class DuyetDonTraController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public DuyetDonTraController(QuanLyCoSoVatChatContext cc)
        {
            this.context = cc;
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
                int PageSize = 7;
                int PageNumber = (page ?? 1);
                var AllData = context.donTra.Include(U => U.users).Include(N => N.nguoiMuon).Include(C => C.chiTietDonTra).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
                IPagedList<DonTra> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }


        [HttpPost]
        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> DuyetDon(int id)
        {
            var donTra = await context.donTra.Where(d => d.maDonTra == id).FirstOrDefaultAsync();
            if (donTra != null)
            {
                if (donTra.chucNang == "Đợi Duyệt")
                {
                    Console.WriteLine($"Giá trị chucNang trước khi cập nhật: {donTra.chucNang}");
                    donTra.chucNang = "Đã Duyệt";
                    Console.WriteLine($"Giá trị chucNang sau khi cập nhật: {donTra.chucNang}");
                    await context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Đơn mượn không ở trạng thái Đợi duyệt.");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}