using Microsoft.AspNetCore.Mvc;

namespace BTVN_2.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Phạm Gia Hân";
            ViewBag.MSSV = "1822040666";
            ViewData["Nam"] = "Năm 2024";
            return View();
        }
    }
}
public class Tuan02Controller : Controller
{

    public IActionResult MayTinh(int a, int b, string pheptinh)
    {
        double PhepTinh;
        if (pheptinh == "cong")
            PhepTinh = a + b;
        else if (pheptinh == "tru")
            PhepTinh = a - b;
        else if (pheptinh == "nhan")
            PhepTinh = a * b;
        else
            PhepTinh = (double)a / b;
        ViewBag.KetQua = PhepTinh;
        return View();
    }
    public IActionResult Profile()
    {
        return View();
    }
}
