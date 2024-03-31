using DoAnMonPhanTichPhanMem.Areas.GiamDoc.Models;
using DoAnMonPhanTichPhanMem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NToastNotify;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoAnMonPhanTichPhanMem.Controllers
{
	public class HomeController : Controller
	{
		private readonly IToastNotification toast;
		private QuanLyCoSoVatChatContext context;
		private readonly ILogger<HomeController> _logger;

		public HomeController(QuanLyCoSoVatChatContext cc ,ILogger<HomeController> logger, IToastNotification toast)
		{
			_logger = logger;
			this.context = cc;
			this.toast = toast;
		}

		[Route("")]
		public IActionResult Index()
		{
			var username = HttpContext.Session.GetString("username");
            var role = HttpContext.Session.GetString("role");
			var CCCD = HttpContext.Session.GetString("CCCD");

            System.Diagnostics.Debug.WriteLine("Role received: " + role);
            System.Diagnostics.Debug.WriteLine("Username from session: " + username);
            System.Diagnostics.Debug.WriteLine("Role from session: " + role);
            if (username != null)
			{

                if (role == "Giám Đốc")
				{
					Users users = context.users.Where(U => U.vaiTro == "Giám Đốc").FirstOrDefault();
					toast.AddSuccessToastMessage("Đăng Nhập Thành Công", new ToastrOptions { Title = "Thông Báo" });
                    return View("~/Areas/GiamDoc/Views/ThongKe/Index.cshtml");
                    
				}
				else if(role == "Quản Lý")
				{
					Users users = context.users.Where(U => U.vaiTro == "Quản Lý").FirstOrDefault();
					toast.AddSuccessToastMessage("Đăng Nhập Thành Công", new ToastrOptions { Title = "Thông Báo" });
                    return View("~/Areas/QuanLy/Views/UsersQL/Index.cshtml");
                   
				}
				else if(role == "Nhân Viên")
				{
                    Users users = context.users.Where(U => U.vaiTro == "Nhân Viên").FirstOrDefault();
					toast.AddSuccessToastMessage("Đăng Nhập Thành Công", new ToastrOptions { Title = "Thông Báo" });
					return View("~/Areas/NhanVien/Views/UsersNV/Index.cshtml");
				}

			}
			return View("Login");
		}
		[HttpGet]
        public IActionResult Login()
        {
			return View();
        }

		[HttpPost]
		public IActionResult Login(TaiKhoan TK)
		{
			//if (ModelState.IsValid)
			//{
				var TKKK = context.taiKhoan.Where(T => T.email.Equals(TK.email) && T.matKhau.Equals(TK.matKhau)).FirstOrDefault();
				if(TKKK != null)
				{
                    var users = context.users.Where(u => u.maNguoiDung == TKKK.maNguoiDung).FirstOrDefault();
					if(users != null)
					{
						string UsersRole = users.vaiTro;
						string CCCD = users.CMND_CCCD;

						HttpContext.Session.SetString("role", UsersRole);
						HttpContext.Session.SetString("chungminhnhandan", CCCD);
						HttpContext.Session.SetString("userImage", TKKK.hinhAnh);
						HttpContext.Session.SetString("tenNguoiDung", users.tenNguoiDung);
						HttpContext.Session.SetString("gioiTinh", users.gioiTinh);
						HttpContext.Session.SetString("ngaySinh", users.ngaySinh.ToShortDateString());
						HttpContext.Session.SetString("CMND_CCCD", users.CMND_CCCD);
						HttpContext.Session.SetString("vaiTro", users.vaiTro);
						HttpContext.Session.SetString("diaChi", users.diaChi);
						HttpContext.Session.SetString("soDienThoai", users.soDienThoai);
						HttpContext.Session.SetString("email", users.email);
						HttpContext.Session.SetString("username", TKKK.email.ToString());
						return RedirectToAction("Index");

                    }
				}
            //}
            toast.AddErrorToastMessage("Sai Tài Khoản Hoặc Mật Khẩu", new ToastrOptions { Title = "Thông Báo" });
            return View("Login");
		}
		public IActionResult Logout()
		{
			if(HttpContext.Session.GetString("username") != null && HttpContext.Session.GetString("role") != null)
			{
                HttpContext.Session.Remove("username");
				HttpContext.Session.Remove("role");
				toast.AddSuccessToastMessage("Đăng Xuất Thành Công", new ToastrOptions { Title = "Thông Báo" });
			}
            return RedirectToAction("Index");
        }
     
    }
}