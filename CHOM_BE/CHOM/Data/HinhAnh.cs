using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    public class HinhAnh
    {
        [Key]
        public int ID { set; get; }
        [Display(Name = "Hình ảnh (Vui lòng chọn 1 ảnh và dung lượng dưới 1MB)")]
        public string? FileName { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string? TieuDe { set; get; }
        [Display(Name = "Dự án")]
        public int IDDuAn { set; get; }
        [ForeignKey("IDDuAn")]
        public virtual DuAn? DuAn { set; get; }
    }
}
