using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    public class HinhAnh
    {
        [Key]
        public int ID { set; get; }
        public string FileName { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string? TieuDe { set; get; }
        public int IDDuAn { set; get; }
        [ForeignKey("IDDuAn")]
        public virtual DuAn? DuAn { set; get; }
    }
}
