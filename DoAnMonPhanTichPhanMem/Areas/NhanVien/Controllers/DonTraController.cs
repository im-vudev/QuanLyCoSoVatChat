using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class DonTraController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public DonTraController(QuanLyCoSoVatChatContext cc)
        {
            context = cc;
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

            }
            int PageSize = 7;
            int PageNumber = (page ?? 1);
            var AllData = context.donTra.Include(U => U.users).Include(D => D.nguoiMuon).Include(C => C.chiTietDonTra).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
            IPagedList<DonTra> PageTra = AllData.ToPagedList(PageNumber, PageSize);
            return View(PageTra);
        }

        [Route("NhanVien/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> US = new List<SelectListItem>();
                List<SelectListItem> NM = new List<SelectListItem>();
                List<SelectListItem> SDT = new List<SelectListItem>();
                List<SelectListItem> DM = new List<SelectListItem>();
                List<SelectListItem> TTCSVC = new List<SelectListItem>();
                //List<SelectListItem> MDM = new List<SelectListItem>();
                TTCSVC = context.thongTinCoSoVatChat.Select(u => new SelectListItem { Text = u.tenThietBi, Value = u.maThietBi.ToString() }).ToList();
                US = context.users.Select(u => new SelectListItem { Text = u.vaiTro, Value = u.maNguoiDung.ToString() }).ToList();
                NM = context.nguoiMuon.Select(N => new SelectListItem { Text = N.hoVaTen, Value = N.maNguoiMuon.ToString() }).ToList();
                SDT = context.nguoiMuon.Select(s => new SelectListItem { Text = s.soDienThoai, Value = s.maNguoiMuon.ToString() }).ToList();
                //MDM = context.nguoiMuon.Select(D => new SelectListItem { Text = D., Value = D.maNguoiMuon.ToString() }).ToList();
                ViewBag.Users = US;
                ViewBag.ThongTinCoSoVatChat = TTCSVC;
                ViewBag.NguoiMuon = NM;
                ViewBag.SoDienThoaiNguoiMuon = SDT;
                return View();
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }

        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Create(DonTra donTra,int maChiTietDonTra, int soLuongTra, string tenThietBi, string moTa, int maThietBi)
        {
            donTra.chucNang = "Đợi Duyệt";
            context.Add(donTra);
            await context.SaveChangesAsync();
            int maDonTra = donTra.maDonTra;
            var TTCSVC = context.thongTinCoSoVatChat.FirstOrDefault(tb => tb.maThietBi == maThietBi);
            if (TTCSVC != null)
            {
                var ChiTietDonTra = new ChiTietDonTra
                {
                    maChiTietDonTra = maChiTietDonTra,
                    soLuongTra = soLuongTra,
                    tenThietBi = tenThietBi,
                    maDonTra = maDonTra,
                    moTa = moTa,
                    maThietBi = maThietBi,
                    donTra = donTra,
                };
                context.Add(ChiTietDonTra);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }

        }
    }
}
