using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("DuAn")]   
    public class DuAn
    {
        public DuAn() { this.HinhAnhs = new HashSet<HinhAnh>(); }
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string TuaDe { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(int.MaxValue)]
        [Display(Name = "Hình")]
        public string HinhGT { get; set; }

        [MaxLength, Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime NgayTao { set; get; }

        public int IDLoai { get; set; }
        [ForeignKey("IDLoai")]
        public virtual Loai? Loai { set; get; }
        public virtual ICollection<HinhAnh>? HinhAnhs { set; get; }


    }
}
