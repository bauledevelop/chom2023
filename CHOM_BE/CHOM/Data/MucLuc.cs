using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("MucLuc")]
    public class MucLuc
    {
        public MucLuc()
        {
            this.DuAns = new HashSet<DuAn>();
            this.BoSuuTams = new HashSet<BoSuuTam>();

        }
        [Key]
        public int ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Tên mục lục")]
        [Required(ErrorMessage = "Vui lòng nhập tên mục lục")]
        public string Ten { set; get; }
        [Display(Name = "Thứ tự")]
        [Required(ErrorMessage = "Vui lòng nhập thứ tự")]
        public int ThuTu { set; get; }
        public string? Link { set; get; }
        [Display(Name = "Mục lục cha")]
        public int? IDParent { set; get; }

        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { set; get; }
        [Display(Name = "Năm")]
        public int? Nam { set; get; }
        public virtual ICollection<DuAn>? DuAns { set; get; }
        public virtual ICollection<BoSuuTam>? BoSuuTams { set; get; }
    }
}
