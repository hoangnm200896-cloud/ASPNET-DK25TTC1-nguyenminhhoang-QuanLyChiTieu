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
        // Cho phép chọn xem theo tháng/năm bất kỳ, mặc định là tháng/năm hiện tại
        public IActionResult Index(int? thang, int? nam)
        {
            var thangXem = (thang.HasValue && thang.Value >= 1 && thang.Value <= 12) ? thang.Value : DateTime.Now.Month;
            var namXem = (nam.HasValue && nam.Value > 0) ? nam.Value : DateTime.Now.Year;

            // Lấy giao dịch trong tháng được chọn
            var giaoDichThang = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .Where(g => g.NgayGiaoDich.Month == thangXem && g.NgayGiaoDich.Year == namXem)
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

            // Giao dịch gần nhất TRONG THÁNG ĐANG XEM (thay vì lấy 5 giao dịch gần nhất toàn hệ thống,
            // để nhất quán với dữ liệu đang hiển thị khi người dùng chọn xem tháng cũ)
            var giaoDichGanNhat = giaoDichThang
                .OrderByDescending(g => g.NgayGiaoDich)
                .ThenByDescending(g => g.NgayTao)
                .Take(5)
                .ToList();

            // Danh sách các năm có dữ liệu để đổ vào dropdown chọn năm
            var danhSachNam = _context.GiaoDichs
                .Select(g => g.NgayGiaoDich.Year)
                .Distinct()
                .OrderByDescending(y => y)
                .ToList();
            if (!danhSachNam.Contains(DateTime.Now.Year))
            {
                danhSachNam.Insert(0, DateTime.Now.Year);
            }

            ViewBag.DanhSachNam = danhSachNam;

            var viewModel = new DashboardViewModel
            {
                TongThuNhap = tongThuNhap,
                TongChiTieu = tongChiTieu,
                SoDu = tongThuNhap - tongChiTieu,
                GiaoDichGanNhat = giaoDichGanNhat,
                ChiTieuTheoDanhMuc = chiTieuTheoDanhMuc,
                ThangHienTai = thangXem,
                NamHienTai = namXem
            };

            return View(viewModel);
        }
    }
}
