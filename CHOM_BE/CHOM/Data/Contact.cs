using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    public class Contact
    {
        [Key]
        public int ID { set; get; }
        [StringLength(100)]
        [Display(Name = "Hình ảnh (Vui lòng chọn một hình và dung lượng không quá 1MB)")]
        public string? HinhAnh { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tên (Vui lòng nhập tên dưới 30 kí tự)")]
        [MaxLength(30,ErrorMessage = "Vui lòng nhập không quá 30 kí tự")]
        public string Ten { set; get; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Giới thiệu")]
        [Required(ErrorMessage = "Vui lòng nhập giới thiệu")]
        public string GioiThieu { set; get; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Cột mốc")]
        [Required(ErrorMessage = "Vui lòng nhập cột mốc")]
        public string CotMoc { set; get; }
    }
}
