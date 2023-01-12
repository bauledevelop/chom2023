﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHOM.Data
{
    [Table("LienHe")]
    public class LienHe
    {
        [Key]
        public int ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Ten { set; get; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string PhuongThuc { set; get; }
    }
}
