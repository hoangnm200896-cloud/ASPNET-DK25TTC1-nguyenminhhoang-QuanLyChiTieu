using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyChiTieu.Data;
using QuanLyChiTieu.Models.ViewModels;

namespace QuanLyChiTieu.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThongKeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang thống kê
        public IActionResult Index(int? thang, int? nam)
        {
            var thangHienTai = thang ?? DateTime.Now.Month;
            var namHienTai = nam ?? DateTime.Now.Year;

            // Lấy giao dịch trong tháng được chọn
            var giaoDichThang = _context.GiaoDichs
                .Include(g => g.DanhMuc)
                .Where(g => g.NgayGiaoDich.Month == thangHienTai && g.NgayGiaoDich.Year == namHienTai)
                .OrderByDescending(g => g.NgayGiaoDich)
                .ToList();

            // Tính tổng thu nhập và chi tiêu trong tháng
            var tongThuNhap = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ThuNhap")
                .Sum(g => g.SoTien);

            var tongChiTieu = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ChiTieu")
                .Sum(g => g.SoTien);

            // Chi tiêu theo danh mục (cho biểu đồ tròn)
            var chiTieuTheoDanhMuc = giaoDichThang
                .Where(g => g.DanhMuc.LoaiDanhMuc == "ChiTieu")
                .GroupBy(g => g.DanhMuc.TenDanhMuc)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.SoTien));

            // Thu chi theo từng tháng trong năm (cho biểu đồ cột)
            var thuNhapTheoThang = new List<decimal>();
            var chiTieuTheoThang = new List<decimal>();

            for (int i = 1; i <= 12; i++)
            {
                var giaoDichThangI = _context.GiaoDichs
                    .Include(g => g.DanhMuc)
                    .Where(g => g.NgayGiaoDich.Month == i && g.NgayGiaoDich.Year == namHienTai)
                    .ToList();

                thuNhapTheoThang.Add(giaoDichThangI.Where(g => g.DanhMuc.LoaiDanhMuc == "ThuNhap").Sum(g => g.SoTien));
                chiTieuTheoThang.Add(giaoDichThangI.Where(g => g.DanhMuc.LoaiDanhMuc == "ChiTieu").Sum(g => g.SoTien));
            }

            var viewModel = new ThongKeViewModel
            {
                Thang = thangHienTai,
                Nam = namHienTai,
                TongThuNhap = tongThuNhap,
                TongChiTieu = tongChiTieu,
                SoDu = tongThuNhap - tongChiTieu,
                ChiTieuTheoDanhMuc = chiTieuTheoDanhMuc,
                ThuNhapTheoThang = thuNhapTheoThang,
                ChiTieuTheoThang = chiTieuTheoThang,
                DanhSachGiaoDich = giaoDichThang
            };

            return View(viewModel);
        }
    }
}
