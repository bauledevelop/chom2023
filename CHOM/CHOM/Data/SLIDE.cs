using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("SLIDE")]   
    public class SLIDE
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Nguồn")]
        public string NGUON { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string LINK { get; set; }
        
        
        
    }
}
