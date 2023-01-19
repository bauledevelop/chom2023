using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("PhanHois")]
    public class PhanHoi
    {
        [Key]
        public int ID { set; get; }
        [Column(TypeName="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Ten { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email")]
        [StringLength(100)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Không đúng định dạng email")]
        public string Email { set; get; }
        [StringLength(20)]
        [MaxLength(15, ErrorMessage = "Vui lòng nhập không quá 15 số")]
        [MinLength(8, ErrorMessage = "Vui lòng nhập hơn 8 số")]
        public string SDT { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập yêu cầu của bạn")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string YeuCau { set; get; }
        
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string NoiDung { set; get; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { set; get; }
    }
}
