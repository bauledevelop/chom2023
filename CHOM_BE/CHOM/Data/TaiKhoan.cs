using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("TaiKhoan")]   
    public class TaiKhoan
    {
        [Key]
        [Required(ErrorMessage = "Username is requried!")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is requried!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

    }
}
