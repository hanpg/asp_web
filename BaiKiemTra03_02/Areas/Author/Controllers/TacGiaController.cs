using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_02.Controllers
{
    [Area("Author")]
    public class TacGiaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TacGiaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tacgia = _db.TacGia.ToList();
            ViewBag.TacGia = tacgia;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                _db.TacGia.Add(tacgia);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }

        [HttpPost]
        public IActionResult Edit(TacGia tacgia)
        {
            if (ModelState.IsValid)
            {
                _db.TacGia.Update(tacgia);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var tacgia = _db.TacGia.Find(id);
            if (tacgia == null)
            {
                return NotFound();
            }
            _db.TacGia.Remove(tacgia);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var tacgia = _db.TacGia.Find(id);
            return View(tacgia);
        }

        [HttpGet]

        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var tacgia = _db.TacGia
                    .Where(tl => tl.TenTacGia.Contains(searchString)).ToList();

                ViewBag.TacGia = tacgia;
            }
            else
            {
                var tacgia = _db.TacGia.ToList();
                ViewBag.TheLoai = tacgia;
            }
            return View("Index");
        }
    }
}
