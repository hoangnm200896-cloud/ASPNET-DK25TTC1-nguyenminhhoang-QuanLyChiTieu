using Microsoft.EntityFrameworkCore;
using QuanLyChiTieu.Models;

namespace QuanLyChiTieu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<GiaoDich> GiaoDichs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng DanhMuc
            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasIndex(e => e.TenDanhMuc).IsUnique();
            });

            // Cấu hình bảng GiaoDich
            modelBuilder.Entity<GiaoDich>(entity =>
            {
                entity.HasOne(g => g.DanhMuc)
                      .WithMany(d => d.GiaoDichs)
                      .HasForeignKey(g => g.MaDanhMuc)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data mẫu - Danh mục
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc { MaDanhMuc = 1, TenDanhMuc = "Lương", LoaiDanhMuc = "ThuNhap", MoTa = "Lương hàng tháng" },
                new DanhMuc { MaDanhMuc = 2, TenDanhMuc = "Thưởng", LoaiDanhMuc = "ThuNhap", MoTa = "Tiền thưởng" },
                new DanhMuc { MaDanhMuc = 3, TenDanhMuc = "Làm thêm", LoaiDanhMuc = "ThuNhap", MoTa = "Thu nhập từ làm thêm" },
                new DanhMuc { MaDanhMuc = 4, TenDanhMuc = "Ăn uống", LoaiDanhMuc = "ChiTieu", MoTa = "Chi phí ăn uống hàng ngày" },
                new DanhMuc { MaDanhMuc = 5, TenDanhMuc = "Di chuyển", LoaiDanhMuc = "ChiTieu", MoTa = "Chi phí đi lại, xăng xe" },
                new DanhMuc { MaDanhMuc = 6, TenDanhMuc = "Học tập", LoaiDanhMuc = "ChiTieu", MoTa = "Học phí, sách vở" },
                new DanhMuc { MaDanhMuc = 7, TenDanhMuc = "Giải trí", LoaiDanhMuc = "ChiTieu", MoTa = "Xem phim, ca nhạc" },
                new DanhMuc { MaDanhMuc = 8, TenDanhMuc = "Mua sắm", LoaiDanhMuc = "ChiTieu", MoTa = "Quần áo, đồ dùng" },
                new DanhMuc { MaDanhMuc = 9, TenDanhMuc = "Tiền nhà", LoaiDanhMuc = "ChiTieu", MoTa = "Tiền thuê nhà, điện nước" },
                new DanhMuc { MaDanhMuc = 10, TenDanhMuc = "Khác", LoaiDanhMuc = "ChiTieu", MoTa = "Chi phí khác" }
            );

            // Seed data mẫu - Giao dịch
            modelBuilder.Entity<GiaoDich>().HasData(
                new GiaoDich { MaGiaoDich = 1, TenGiaoDich = "Lương tháng 6", SoTien = 8000000, NgayGiaoDich = new DateTime(2024, 6, 5), MaDanhMuc = 1, GhiChu = "Lương tháng 6/2024", NgayTao = new DateTime(2024, 6, 5) },
                new GiaoDich { MaGiaoDich = 2, TenGiaoDich = "Ăn sáng + trưa", SoTien = 50000, NgayGiaoDich = new DateTime(2024, 6, 6), MaDanhMuc = 4, GhiChu = "", NgayTao = new DateTime(2024, 6, 6) },
                new GiaoDich { MaGiaoDich = 3, TenGiaoDich = "Đổ xăng xe máy", SoTien = 80000, NgayGiaoDich = new DateTime(2024, 6, 7), MaDanhMuc = 5, GhiChu = "Đổ đầy bình", NgayTao = new DateTime(2024, 6, 7) },
                new GiaoDich { MaGiaoDich = 4, TenGiaoDich = "Mua sách lập trình", SoTien = 150000, NgayGiaoDich = new DateTime(2024, 6, 8), MaDanhMuc = 6, GhiChu = "Sách ASP.NET", NgayTao = new DateTime(2024, 6, 8) },
                new GiaoDich { MaGiaoDich = 5, TenGiaoDich = "Xem phim cuối tuần", SoTien = 90000, NgayGiaoDich = new DateTime(2024, 6, 9), MaDanhMuc = 7, GhiChu = "2 vé phim", NgayTao = new DateTime(2024, 6, 9) },
                new GiaoDich { MaGiaoDich = 6, TenGiaoDich = "Tiền nhà tháng 6", SoTien = 2000000, NgayGiaoDich = new DateTime(2024, 6, 1), MaDanhMuc = 9, GhiChu = "Tiền phòng trọ", NgayTao = new DateTime(2024, 6, 1) },
                new GiaoDich { MaGiaoDich = 7, TenGiaoDich = "Làm thêm quán cafe", SoTien = 1500000, NgayGiaoDich = new DateTime(2024, 6, 15), MaDanhMuc = 3, GhiChu = "Lương part-time", NgayTao = new DateTime(2024, 6, 15) },
                new GiaoDich { MaGiaoDich = 8, TenGiaoDich = "Mua áo mới", SoTien = 250000, NgayGiaoDich = new DateTime(2024, 6, 10), MaDanhMuc = 8, GhiChu = "", NgayTao = new DateTime(2024, 6, 10) },
                new GiaoDich { MaGiaoDich = 9, TenGiaoDich = "Ăn tối với bạn", SoTien = 120000, NgayGiaoDich = new DateTime(2024, 6, 12), MaDanhMuc = 4, GhiChu = "Nhậu với đám bạn", NgayTao = new DateTime(2024, 6, 12) },
                new GiaoDich { MaGiaoDich = 10, TenGiaoDich = "Cà phê sáng", SoTien = 30000, NgayGiaoDich = new DateTime(2024, 6, 14), MaDanhMuc = 4, GhiChu = "", NgayTao = new DateTime(2024, 6, 14) }
            );
        }
    }
}
