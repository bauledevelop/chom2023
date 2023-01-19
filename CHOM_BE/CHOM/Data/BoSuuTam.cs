using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("BoSuuTam")]
    public class BoSuuTam
    {
        [Key]
        public int ID { set; get; }
        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string? HinhAnh { set; get; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTao { set; get; }
        [Display(Name = "Mục lục")]
        public int IDMucLuc { set; get; }
        [ForeignKey("IDMucLuc")]
        public virtual MucLuc? MucLuc { set; get; }
    }
}
