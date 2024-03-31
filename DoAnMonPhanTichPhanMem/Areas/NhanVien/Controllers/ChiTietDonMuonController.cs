using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class ChiTietDonMuonController : Controller
    {

        private QuanLyCoSoVatChatContext context;
        public ChiTietDonMuonController(QuanLyCoSoVatChatContext cc)
        {
            this.context = cc;
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
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            var data = context.chiTietDonMuon.Include(L => L.donMuon).Include(N => N.thongTinCoSoVatChat).ToList();

            IPagedList<ChiTietDonMuon> pagedData = data.ToPagedList(pageNumber, pageSize);

            return View(pagedData);
        }
    }
}
