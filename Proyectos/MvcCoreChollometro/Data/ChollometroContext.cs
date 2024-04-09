using Microsoft.EntityFrameworkCore;
using MvcCoreChollometro.Models;
using System.Collections.Generic;

namespace MvcCoreChollometro.Data
{
    public class ChollometroContext : DbContext
    {
        public ChollometroContext(DbContextOptions<ChollometroContext> options)
            : base(options) { }

        public DbSet<Chollo> Chollos { get; set; }
    }
}
