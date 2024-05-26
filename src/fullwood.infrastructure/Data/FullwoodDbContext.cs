using fullwood.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace fullwood.infrastructure.Data
{
    public class FullwoodDbContext : DbContext
    {
        public FullwoodDbContext(DbContextOptions<FullwoodDbContext> options) : base(options)
        { }

        public DbSet<Cow> Cows { get; set; }
        public DbSet<Milking> Milkings { get; set; }
    }
}
