namespace QuanLyChiTieu.Models.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TongThuNhap { get; set; }
        public decimal TongChiTieu { get; set; }
        public decimal SoDu { get; set; }
        public List<GiaoDich> GiaoDichGanNhat { get; set; }
        public Dictionary<string, decimal> ChiTieuTheoDanhMuc { get; set; }
        public int ThangHienTai { get; set; }
        public int NamHienTai { get; set; }
    }
}
