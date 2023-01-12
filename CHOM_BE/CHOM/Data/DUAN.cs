using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("DUAN")]   
    public class DUAN
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string TUADE { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string HINHGT { get; set; }

        [MaxLength, Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        public int MaThuVien { get; set; }
        [ForeignKey("MaThuVien")]
        public THUVIEN? THUVIENs { get; set; }
 


    }
}
