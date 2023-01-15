using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("About")]   
    public class About
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string TuaDe { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Nội dung")]
        [MaxLength(500)]
        public string NoiDung { get; set; }
    }
}
