using System.ComponentModel.DataAnnotations;

namespace CHOM.Data
{
    public class Video
    {
        [Key]
        public int ID { set; get; }
        [Required(ErrorMessage = "Vui lòng chọn video ")]
        public string FileName { set; get; }
    }
}
