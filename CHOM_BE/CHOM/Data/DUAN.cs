using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("DuAn")]   
    public class DuAn
    {
        public DuAn() { this.HinhAnhs = new HashSet<HinhAnh>(); }
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập tên dự án")]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tên dự án")]
        [MaxLength(100)]
        public string TuaDe { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        [Required(ErrorMessage = "Vui lòng chọn hình giới thiệu")]
        public string HinhGT { get; set; }

        [MaxLength, Column(TypeName = "ntext")]
        [Display]
        public string? NoiDung { get; set; }
        [Display(Name ="Năm")]
        [Required(ErrorMessage = "Vui lòng chọn năm")]
        public int Nam { set; get; }
        [Display(Name = "Mục lục")]
        public int IDMucLuc { get; set; }
        [ForeignKey("IDMucLuc")]
        public virtual MucLuc? MucLuc { set; get; }
        public virtual ICollection<HinhAnh>? HinhAnhs { set; get; }
    }
}
