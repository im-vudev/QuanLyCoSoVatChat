using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class ChiTietDonMuonController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public ChiTietDonMuonController(QuanLyCoSoVatChatContext cc)
        {
            this.context = cc;
        }
        private bool CheckLogin()
        {
            if(HttpContext.Session.GetString("role") == "Giám Đốc")
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
                var AllData = context.donMuon.Include(U => U.users).Include(N => N.nguoiMuon).Include(C => C.chiTietDonMuon).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
                IPagedList<DonMuon> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }
        [HttpPost]
        [Route("GiamDoc/[controller]/[action]")]
        public async Task<IActionResult> Delete(int idChiTietDonMuon, int idDonMuon)
        {
            var CTDM = new ChiTietDonMuon { maChiTietDonMuon = idChiTietDonMuon };
            context.Remove(CTDM);
            await context.SaveChangesAsync();

            var DM = new DonMuon { maDonMuon = idDonMuon };
            context.Remove(DM);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
