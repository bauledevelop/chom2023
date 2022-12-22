using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("ABOUT")]   
    public class ABOUT
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string TUADE { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Nội dung")]
        [MaxLength(500)]
        public string NOIDUNG { get; set; }
         


    }
}
