using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (model == null)
            {
                return Content(model.Username);
            }
            return View();
        }

        public IActionResult BaiTap2()
        {
            var sanpham = new SanPhamViewModel();
            ViewBag.TenSP = "Combo gội xả TREsemme";
            ViewBag.Gia = "250000VND";
            return View(sanpham);
        }
    }
}
