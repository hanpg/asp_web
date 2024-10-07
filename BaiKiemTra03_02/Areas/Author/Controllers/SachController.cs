using Microsoft.EntityFrameworkCore;
using BaiKiemTra03_02.Models;
using BaiKiemTra03_02.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Authorization;

namespace BaiKiemTra03_02.Controllers
{
    [Area("Author")]
    public class SachController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SachController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Sach> sach = _db.Sach.Include("TacGia").ToList();
            return View(sach);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Sach sach = new Sach();
            IEnumerable<SelectListItem> dstacgia = _db.TacGia.Select(
                item => new SelectListItem
                {
                    Value = item.MaTacGia.ToString(),
                    Text = item.TenTacGia,
                }
            );
            ViewBag.DSTacGia = dstacgia;
            if (id == 0)
            {
                return View(sach);
            }
            else
            {
                sach = _db.Sach.Include("TacGia").FirstOrDefault(sa => sa.BookId == id);
                return View(sach);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Sach sach)
        {
            if (ModelState.IsValid)
            {
                if (sach.BookId == 0)
                {
                    _db.Sach.Add(sach);
                }
                else
                {
                    _db.Sach.Update(sach);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var sach = _db.Sach.FirstOrDefault(sa => sa.BookId == id);
            if (sach == null)
            {
                return NotFound();
            }
            _db.Sach.Remove(sach);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
