using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie_Cole.Models;

namespace RazorPagesMovie_Cole.Data
{
    public class RazorPagesMovie_ColeContext : DbContext
    {
        public RazorPagesMovie_ColeContext (DbContextOptions<RazorPagesMovie_ColeContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie_Cole.Models.Movie> Movie { get; set; } = default!;
    }
}
