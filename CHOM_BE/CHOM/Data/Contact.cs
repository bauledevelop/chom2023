using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    public class Contact
    {
        [Key]
        public int ID { set; get; }
        [StringLength(100)]
        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tên")]
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
