using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyChiTieu.Data;
using QuanLyChiTieu.Models.ViewModels;

namespace QuanLyChiTieu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang chủ - Dashboard
        public IActionResult Index()
        {
            var thang = DateTime.Now.Month;
            var nam = DateTime.Now.Year;

            // Lấy giao dịch trong tháng hiện tại
            var giaoDichThang = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .Where(g => g.NgayGiaoDich.Month == thang && g.NgayGiaoDich.Year == nam)
                .ToList();

            // Tính tổng thu nhập
            var tongThuNhap = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ThuNhap")
                .Sum(g => g.SoTien);

            // Tính tổng chi tiêu
            var tongChiTieu = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ChiTieu")
                .Sum(g => g.SoTien);

            // Chi tiêu theo danh mục
            var chiTieuTheoDanhMuc = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ChiTieu")
                .GroupBy(g => g.DanhMuc.TenDanhMuc)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.SoTien));

            // 5 giao dịch gần nhất
            var giaoDichGanNhat = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .OrderByDescending(g => g.NgayGiaoDich)
                .ThenByDescending(g => g.NgayTao)
                .Take(5)
                .ToList();

            var viewModel = new DashboardViewModel
            {
                TongThuNhap = tongThuNhap,
                TongChiTieu = tongChiTieu,
                SoDu = tongThuNhap - tongChiTieu,
                GiaoDichGanNhat = giaoDichGanNhat,
                ChiTieuTheoDanhMuc = chiTieuTheoDanhMuc,
                ThangHienTai = thang,
                NamHienTai = nam
            };

            return View(viewModel);
        }
    }
}
