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
        [Display(Name = "Tên dự án (Vui lòng viết dưới 50 kí tự)")]
        [MaxLength(100)]
        [StringLength(maximumLength: 50, ErrorMessage = "Không nhập quá 50 ký tự")]
        public string TuaDe { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string? HinhGT { get; set; }

        [MaxLength, Column(TypeName = "ntext")]
        [Display]
        public string? NoiDung { get; set; }
        [Display(Name ="Năm (Vui lòng nhập số)")]
        [Required(ErrorMessage = "Vui lòng chọn năm")]
        public int Nam { set; get; }
        [Display(Name = "Loại")]
        public int IDMucLuc { get; set; }
        [ForeignKey("IDMucLuc")]
        public virtual MucLuc? MucLuc { set; get; }
        public virtual ICollection<HinhAnh>? HinhAnhs { set; get; }
    }
}
