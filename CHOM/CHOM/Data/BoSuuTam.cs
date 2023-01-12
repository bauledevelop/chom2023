using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("BoSuuTam")]
    public class BoSuuTam
    {
        [Key]
        public int ID { set; get; }
        public string HinhAnh { set; get; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTao { set; get; }
        public int IDLoai { set; get; }
        [ForeignKey("IDLoai")]
        public virtual Loai? Loai { set; get; }
    }
}
