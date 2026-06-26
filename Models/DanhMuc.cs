using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChiTieu.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDanhMuc { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không quá 100 ký tự")]
        [Display(Name = "Tên danh mục")]
        public string TenDanhMuc { get; set; }

        [Required(ErrorMessage = "Loại danh mục không được để trống")]
        [Display(Name = "Loại danh mục")]
        public string LoaiDanhMuc { get; set; } // "ThuNhap" hoặc "ChiTieu"

        [StringLength(255, ErrorMessage = "Mô tả không quá 255 ký tự")]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        // Navigation property
        public virtual ICollection<GiaoDich> GiaoDichs { get; set; }
    }
}
