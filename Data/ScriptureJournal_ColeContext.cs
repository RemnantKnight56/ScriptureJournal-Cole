using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal_Cole.Models;

namespace ScriptureJournal_Cole.Data
{
    public class ScriptureJournal_ColeContext : DbContext
    {
        public ScriptureJournal_ColeContext (DbContextOptions<ScriptureJournal_ColeContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal_Cole.Models.Scripture> Scripture { get; set; } = default!;
    }
}
