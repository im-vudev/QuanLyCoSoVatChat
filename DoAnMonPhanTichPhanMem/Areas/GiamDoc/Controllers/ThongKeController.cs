using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace DoAnMonPhanTichPhanMem.Areas.GiamDoc.Controllers
{
    [Area("GiamDoc")]
    public class ThongKeController : Controller
    {
    
        //private readonly IServiceProvider serviceProvider;
        //private readonly ILogger<ThongKeController> logger;
        private QuanLyCoSoVatChatContext context;
        public ThongKeController(QuanLyCoSoVatChatContext cc)
        {
            this.context = cc;

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
        public async Task<IActionResult> Index()
        {
            if (CheckLogin())
            {
                // Truy vấn cơ sở dữ liệu để lấy số lượng từ bảng thông tin cơ sở vật chất
                var soLuongTuCoSoVatChat = await context.thongTinCoSoVatChat.SumAsync(t => t.soLuong);
                var CCDonMuon = await context.chiTietDonMuon.SumAsync(d => d.soLuongMuon);
                var CSVCDSD = await context.chiTietDonTra.SumAsync(d => d.soLuongTra);
                var Hong = await context.donTra.Where(d => d.trangThai == "Hư Hỏng").CountAsync();

                // Gán giá trị vào ViewBag
                ViewBag.SoLuongThietBi = soLuongTuCoSoVatChat;
                ViewBag.SoLuonMuon = CCDonMuon;
                ViewBag.SoLuongTra = CSVCDSD;
                ViewBag.Hong = Hong;


                return View();
            }
            return View("~/Areas/GiamDoc/Views/Share/PageNotFound.cshtml");
        }
    }
}
