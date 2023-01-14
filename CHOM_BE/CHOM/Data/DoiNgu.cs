using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    public class DoiNgu
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng điền tên nhân viên")]
        public string Ten { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { set; get; }
        [Display(Name = "Chức vụ")]
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string CongViec { set; get; }
    }
}
