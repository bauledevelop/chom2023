using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CHOM.Data
{
    public class CHOMContext : DbContext
    {
        public CHOMContext (DbContextOptions<CHOMContext> options)
            : base(options)
        {
        }
        public virtual DbSet<MucLuc> MucLucs { set; get; } = default!;
        public virtual DbSet<HinhAnh> HinhAnhs { set; get; } = default!;
        public virtual DbSet<About> Abouts { set; get; } = default!;
        public virtual DbSet<BoSuuTam> BoSuuTams { set; get; } = default!;
        public virtual DbSet<DuAn> DuAns { set; get; } = default!;
        public virtual DbSet<LienHe> LienHes { set; get; } = default!;
        public virtual DbSet<Loai> Loais { set; get; } = default!;
        public virtual DbSet<TaiKhoan> TaiKhoans { set; get; } = default!;
    }
}
