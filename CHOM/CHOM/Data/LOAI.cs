using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("LOAI")]   
    public class LOAI
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string HINH { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string TUADE { get; set; }
       


    }
}
