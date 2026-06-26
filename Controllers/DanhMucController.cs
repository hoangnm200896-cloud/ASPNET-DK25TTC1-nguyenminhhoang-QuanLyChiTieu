using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyChiTieu.Data;
using QuanLyChiTieu.Models;

namespace QuanLyChiTieu.Controllers
{
    public class DanhMucController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhMucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách danh mục
        public IActionResult Index()
        {
            var danhMucs = _context.DanhMucs.OrderBy(d => d.LoaiDanhMuc).ThenBy(d => d.TenDanhMuc).ToList();
            return View(danhMucs);
        }

        // Form thêm danh mục
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm danh mục
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DanhMuc danhMuc)
        {
            // Kiểm tra tên danh mục trùng
            if (_context.DanhMucs.Any(d => d.TenDanhMuc == danhMuc.TenDanhMuc))
            {
                ModelState.AddModelError("TenDanhMuc", "Tên danh mục đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _context.DanhMucs.Add(danhMuc);
                _context.SaveChanges();
                TempData["ThongBao"] = "Thêm danh mục thành công!";
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        // Form sửa danh mục
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var danhMuc = _context.DanhMucs.Find(id);
            if (danhMuc == null)
                return NotFound();

            return View(danhMuc);
        }

        // Xử lý sửa danh mục
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DanhMuc danhMuc)
        {
            if (id != danhMuc.MaDanhMuc)
                return NotFound();

            // Kiểm tra tên trùng (trừ chính nó)
            if (_context.DanhMucs.Any(d => d.TenDanhMuc == danhMuc.TenDanhMuc && d.MaDanhMuc != id))
            {
                ModelState.AddModelError("TenDanhMuc", "Tên danh mục đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                _context.Update(danhMuc);
                _context.SaveChanges();
                TempData["ThongBao"] = "Cập nhật danh mục thành công!";
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        // Trang xác nhận xóa
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var danhMuc = _context.DanhMucs.Find(id);
            if (danhMuc == null)
                return NotFound();

            return View(danhMuc);
        }

        // Xử lý xóa danh mục
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var danhMuc = _context.DanhMucs.Find(id);

            // Kiểm tra có giao dịch liên quan không
            var coGiaoDich = _context.GiaoDichs.Any(g => g.MaDanhMuc == id);
            if (coGiaoDich)
            {
                TempData["Loi"] = "Không thể xóa danh mục này vì có giao dịch liên quan!";
                return RedirectToAction("Index");
            }

            _context.DanhMucs.Remove(danhMuc);
            _context.SaveChanges();
            TempData["ThongBao"] = "Xóa danh mục thành công!";
            return RedirectToAction("Index");
        }
    }
}
