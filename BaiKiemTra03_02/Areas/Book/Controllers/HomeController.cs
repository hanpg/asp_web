using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using System.Diagnostics;

namespace ProjectA.Areas.Customer.Controllers
{
    [Area("Book")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Sach> sach = _db.Sach.Include("TacGia").ToList();
            return View(sach);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
