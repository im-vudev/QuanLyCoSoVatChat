using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonPhanTichPhanMem.Areas.QuanLy.Controllers
{
    [Area("QuanLy")]
    public class DuyetDonController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public DuyetDonController(QuanLyCoSoVatChatContext cc)
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
                var AllData = context.donMuon.Include(U => U.users).Include(N => N.nguoiMuon).Include(C => C.chiTietDonMuon).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
                IPagedList<DonMuon> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/QuanLy/Views/Share/PageNotFound.cshtml");
        }


        [HttpPost]
        [Route("QuanLy/[controller]/[action]")]
        public async Task<IActionResult> DuyetDon(int id)
        {
            var donMuon = await context.donMuon.Where(d => d.maDonMuon == id).FirstOrDefaultAsync();
            if (donMuon != null)
            {
                if (donMuon.chucNang == "Đợi Duyệt")
                {
                    Console.WriteLine($"Giá trị chucNang trước khi cập nhật: {donMuon.chucNang}");
                    donMuon.chucNang = "Đã Duyệt";
                    Console.WriteLine($"Giá trị chucNang sau khi cập nhật: {donMuon.chucNang}");
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
