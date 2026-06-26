using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyChiTieu.Data;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Models.ViewModels;

namespace QuanLyChiTieu.Controllers
{
    public class GiaoDichController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiaoDichController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách giao dịch + Tìm kiếm
        public IActionResult Index(string tuKhoa, int? maDanhMuc, DateTime? tuNgay, DateTime? denNgay, string loaiGiaoDich, int page = 1)
        {
            int pageSize = 10;

            // Bắt đầu query
            var query = _context.GiaoDichs.Include(g => g.DanhMuc).AsQueryable();

            // Tìm kiếm tương đối theo tên
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(g => g.TenGiaoDich.Contains(tuKhoa) || g.GhiChu.Contains(tuKhoa));
            }

            // Lọc theo danh mục
            if (maDanhMuc.HasValue && maDanhMuc > 0)
            {
                query = query.Where(g => g.MaDanhMuc == maDanhMuc);
            }

            // Lọc theo khoảng thời gian
            if (tuNgay.HasValue)
            {
                query = query.Where(g => g.NgayGiaoDich >= tuNgay.Value);
            }
            if (denNgay.HasValue)
            {
                query = query.Where(g => g.NgayGiaoDich <= denNgay.Value);
            }

            // Lọc theo loại giao dịch
            if (!string.IsNullOrEmpty(loaiGiaoDich))
            {
                query = query.Where(g => g.DanhMuc.LoaiDanhMuc == loaiGiaoDich);
            }

            // Đếm tổng số bản ghi
            var tongSo = query.Count();
            var tongTrang = (int)Math.Ceiling(tongSo / (double)pageSize);

            // Phân trang
            var danhSach = query
                .OrderByDescending(g => g.NgayGiaoDich)
                .ThenByDescending(g => g.NgayTao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Truyền dữ liệu cho View
            ViewBag.TuKhoa = tuKhoa;
            ViewBag.MaDanhMuc = maDanhMuc;
            ViewBag.TuNgay = tuNgay?.ToString("yyyy-MM-dd");
            ViewBag.DenNgay = denNgay?.ToString("yyyy-MM-dd");
            ViewBag.LoaiGiaoDich = loaiGiaoDich;
            ViewBag.TrangHienTai = page;
            ViewBag.TongTrang = tongTrang;
            ViewBag.TongSo = tongSo;
            ViewBag.DanhSachDanhMuc = _context.DanhMucs.OrderBy(d => d.TenDanhMuc).ToList();

            return View(danhSach);
        }

        // Chi tiết giao dịch
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var giaoDich = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .FirstOrDefault(g => g.MaGiaoDich == id);

            if (giaoDich == null)
                return NotFound();

            return View(giaoDich);
        }

        // Form thêm giao dịch
        public IActionResult Create()
        {
            ViewBag.DanhSachDanhMuc = new SelectList(_context.DanhMucs.OrderBy(d => d.LoaiDanhMuc).ThenBy(d => d.TenDanhMuc), "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        // Xử lý thêm giao dịch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GiaoDich giaoDich)
        {
            if (ModelState.IsValid)
            {
                giaoDich.NgayTao = DateTime.Now;
                _context.GiaoDichs.Add(giaoDich);
                _context.SaveChanges();
                TempData["ThongBao"] = "Thêm giao dịch thành công!";
                return RedirectToAction("Index");
            }
            ViewBag.DanhSachDanhMuc = new SelectList(_context.DanhMucs.OrderBy(d => d.LoaiDanhMuc).ThenBy(d => d.TenDanhMuc), "MaDanhMuc", "TenDanhMuc", giaoDich.MaDanhMuc);
            return View(giaoDich);
        }

        // Form sửa giao dịch
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var giaoDich = _context.GiaoDichs.Find(id);
            if (giaoDich == null)
                return NotFound();

            ViewBag.DanhSachDanhMuc = new SelectList(_context.DanhMucs.OrderBy(d => d.LoaiDanhMuc).ThenBy(d => d.TenDanhMuc), "MaDanhMuc", "TenDanhMuc", giaoDich.MaDanhMuc);
            return View(giaoDich);
        }

        // Xử lý sửa giao dịch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GiaoDich giaoDich)
        {
            if (id != giaoDich.MaGiaoDich)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(giaoDich);
                _context.SaveChanges();
                TempData["ThongBao"] = "Cập nhật giao dịch thành công!";
                return RedirectToAction("Index");
            }
            ViewBag.DanhSachDanhMuc = new SelectList(_context.DanhMucs.OrderBy(d => d.LoaiDanhMuc).ThenBy(d => d.TenDanhMuc), "MaDanhMuc", "TenDanhMuc", giaoDich.MaDanhMuc);
            return View(giaoDich);
        }

        // Trang xác nhận xóa
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var giaoDich = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .FirstOrDefault(g => g.MaGiaoDich == id);

            if (giaoDich == null)
                return NotFound();

            return View(giaoDich);
        }

        // Xử lý xóa giao dịch
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var giaoDich = _context.GiaoDichs.Find(id);
            _context.GiaoDichs.Remove(giaoDich);
            _context.SaveChanges();
            TempData["ThongBao"] = "Xóa giao dịch thành công!";
            return RedirectToAction("Index");
        }
    }
}
