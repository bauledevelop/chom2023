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

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu (Vui lòng không nhập quá 20 kí tự)")]
        [MaxLength(20,ErrorMessage = "Vui lòng không nhập quá 20 kí tự")]
        public string Password { get; set; }

    }
}
