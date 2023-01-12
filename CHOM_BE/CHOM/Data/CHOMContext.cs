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

        public DbSet<CHOM.Data.DUAN> DUAN { get; set; } = default!;
        public DbSet<CHOM.Data.LOAI> LOAI { get; set; } = default!;
        public DbSet<CHOM.Data.SLIDE> SLIDE { get; set; } = default!;
        public DbSet<CHOM.Data.THUVIEN> THUVIEN{ get; set; } = default!;
        public DbSet<CHOM.Data.ABOUT> ABOUT{ get; set; } = default!;
        public DbSet<CHOM.Data.USER> USER { get; set; } = default!;
    }
}
