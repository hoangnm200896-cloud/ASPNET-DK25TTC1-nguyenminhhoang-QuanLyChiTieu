using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChiTieu.Models
{
    [Table("GiaoDich")]
    public class GiaoDich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaGiaoDich { get; set; }

        [Required(ErrorMessage = "Tên giao dịch không được để trống")]
        [StringLength(200, ErrorMessage = "Tên giao dịch không quá 200 ký tự")]
        [Display(Name = "Tên giao dịch")]
        public string TenGiaoDich { get; set; }

        [Required(ErrorMessage = "Số tiền không được để trống")]
        [Range(1, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Số tiền")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal SoTien { get; set; }

        [Required(ErrorMessage = "Ngày giao dịch không được để trống")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày giao dịch")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayGiaoDich { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        [Display(Name = "Danh mục")]
        public int MaDanhMuc { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không quá 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("MaDanhMuc")]
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
