using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using DoAnMonPhanTichPhanMem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.WebSockets;
using X.PagedList;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAnMonPhanTichPhanMem.Areas.NhanVien.Controllers
{
    [Area("NhanVien")]
    public class DonMuonController : Controller
    {
        private QuanLyCoSoVatChatContext context;
        public DonMuonController(QuanLyCoSoVatChatContext cc)
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
            if (CheckLogin())
            {
                int PageSize = 7;
                int PageNumber = (page ?? 1);
                var AllData = context.donMuon.Include(U => U.users).Include(N => N.nguoiMuon).Include(C => C.chiTietDonMuon).ThenInclude(T => T.thongTinCoSoVatChat).Where(d => d.chucNang == "đợi duyệt" || d.chucNang == "đã duyệt").ToList();
                IPagedList<DonMuon> PageData = AllData.ToPagedList(PageNumber, PageSize);
                return View(PageData);
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }
        [Route("NhanVien/[controller]/[action]")]
        public IActionResult Create()
        {
            if (CheckLogin())
            {
                List<SelectListItem> NM = new List<SelectListItem>();
                List<SelectListItem> US = new List<SelectListItem>();
                List<SelectListItem> SDT = new List<SelectListItem>();
                List<SelectListItem> TTCSVC = new List<SelectListItem>();
                TTCSVC = context.thongTinCoSoVatChat.Select(T => new SelectListItem { Text = T.tenThietBi, Value = T.maThietBi.ToString() }).ToList();
                US = context.users.Select(U => new SelectListItem { Text = U.vaiTro, Value = U.maNguoiDung.ToString() }).ToList();
                NM = context.nguoiMuon.Select(N => new SelectListItem { Text = N.hoVaTen, Value = N.maNguoiMuon.ToString() }).ToList();
                SDT = context.nguoiMuon.Select(S => new SelectListItem { Text = S.soDienThoai, Value = S.maNguoiMuon.ToString() }).ToList();
                ViewBag.ThongTinCoSoVatChat = TTCSVC;
                ViewBag.Users = US;
                ViewBag.NguoiMuon = NM;
                ViewBag.SoDienThoaiNguoiMuon = SDT;
                return View();
            }
            return View("~/Areas/NhanVien/Views/Share/PageNotFound.cshtml");
        }
        [HttpPost]
        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> Create(DonMuon donMuon,int maChiTietDonMuon,string trangThai, int soLuongMuon, DateTime ngayTraDuKien, DateTime ngayTraThucTe, int maThietBi)
        {
            donMuon.chucNang = "Đợi Duyệt";
            context.Add(donMuon);
            await context.SaveChangesAsync();
            await context.SaveChangesAsync();
            int maDonMuon = donMuon.maDonMuon;
            var TTCSVC = context.thongTinCoSoVatChat.FirstOrDefault(tb => tb.maThietBi == maThietBi);
            if (TTCSVC != null)
            {
                var ChiTietDonMuon = new ChiTietDonMuon
                {
                    maChiTietDonMuon = maChiTietDonMuon,
                    soLuongMuon = soLuongMuon,
                    ngayTraDuKien = ngayTraDuKien,
                    ngayTraThucTe = ngayTraThucTe,
                    trangThai = trangThai,
                    maDonMuon = maDonMuon,
                    maThietBi = maThietBi,
					donMuon = donMuon,
				};

                context.Add(ChiTietDonMuon);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("đas");
            }
        }

        [Route("NhanVien/[controller]/[action]")]
        public async Task<IActionResult> DuyetDonMuon(int maDonMuon)
        {
            var donMuon = context.donMuon.FirstOrDefault(dm => dm.maDonMuon == maDonMuon);
            if (donMuon != null)
            {
                // Thay đổi trạng thái của đơn mượn từ "đợi duyệt" sang "đã duyệt"
                donMuon.chucNang = "Đã duyệt";
                context.Update(donMuon);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
