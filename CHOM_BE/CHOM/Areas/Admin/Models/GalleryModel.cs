using System.ComponentModel.DataAnnotations;

namespace CHOM.Areas.Admin.Models
{
    public class GalleryModel
    {
        public int ID { set; get; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { set; get; }

        public DateTime NgayTao { set; get; }
        public int IDMucLuc { set; get; }
    }
}
