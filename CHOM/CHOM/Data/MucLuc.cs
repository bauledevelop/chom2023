using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("MucLuc")]
    public class MucLuc
    {
        public MucLuc()
        {
            this.Loais = new HashSet<Loai>();
        }
        [Key]
        public int ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Ten { set; get; }
        public int ThuTu { set; get; }
        public virtual ICollection<Loai>? Loais { set; get; }
    }
}
