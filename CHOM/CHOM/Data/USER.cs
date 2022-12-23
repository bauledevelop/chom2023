using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("USER")]   
    public class USER
    {
        [Key]
        [Required(ErrorMessage = "Username is requried!")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is requried!")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

    }
}
