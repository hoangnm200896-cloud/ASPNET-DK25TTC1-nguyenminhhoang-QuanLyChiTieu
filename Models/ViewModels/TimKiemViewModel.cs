using System.ComponentModel.DataAnnotations;

namespace QuanLyChiTieu.Models.ViewModels
{
    public class TimKiemViewModel
    {
        [Display(Name = "Từ khóa")]
        public string TuKhoa { get; set; }

        [Display(Name = "Danh mục")]
        public int? MaDanhMuc { get; set; }

        [Display(Name = "Từ ngày")]
        [DataType(DataType.Date)]
        public DateTime? TuNgay { get; set; }

        [Display(Name = "Đến ngày")]
        [DataType(DataType.Date)]
        public DateTime? DenNgay { get; set; }

        [Display(Name = "Loại")]
        public string LoaiGiaoDich { get; set; }

        public List<GiaoDich> KetQua { get; set; }
        public List<DanhMuc> DanhSachDanhMuc { get; set; }
    }
}
