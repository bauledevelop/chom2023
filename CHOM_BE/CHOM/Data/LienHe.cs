using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("LienHe")]
    public class LienHe
    {
        [Key]
        public int ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập kí tự")]
        [MaxLength(100,ErrorMessage = "Vui lòng không nhập quá 50 kí tự")]
        public string Ten { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Phương thức")]
        [Required(ErrorMessage = "Vui lòng nhập phương thức ")]
        public string PhuongThuc { set; get; }
    }
}
