using System.ComponentModel.DataAnnotations;

namespace QuanLyChiTieu.Models.ViewModels
{
    public class ThongKeViewModel
    {
        [Display(Name = "Tháng")]
        public int Thang { get; set; }

        [Display(Name = "Năm")]
        public int Nam { get; set; }

        public decimal TongThuNhap { get; set; }
        public decimal TongChiTieu { get; set; }
        public decimal SoDu { get; set; }

        // Dữ liệu cho biểu đồ cột - thu chi theo từng tháng trong năm
        public List<decimal> ThuNhapTheoThang { get; set; } = new List<decimal>();
        public List<decimal> ChiTieuTheoThang { get; set; } = new List<decimal>();

        // Dữ liệu cho biểu đồ tròn - chi tiêu theo danh mục
        public Dictionary<string, decimal> ChiTieuTheoDanhMuc { get; set; } = new Dictionary<string, decimal>();

        // Danh sách giao dịch trong tháng
        public List<GiaoDich> DanhSachGiaoDich { get; set; } = new List<GiaoDich>();
    }
}
