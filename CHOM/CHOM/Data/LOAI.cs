using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("Loai")]   
    public class Loai
    {
        public Loai()
        {
            this.DuAns = new HashSet<DuAn>();
            this.BoSuuTams = new HashSet<BoSuuTam>();
        }
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Ten { get; set; }
        public string IDMucLuc { set; get; }
        public virtual MucLuc? MucLuc { set; get; }
        public virtual ICollection<DuAn>? DuAns { set; get; }
        public virtual ICollection<BoSuuTam>? BoSuuTams { set; get; }
    }
}
