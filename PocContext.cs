using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;

namespace pgsql_poc
{
    public sealed class PocContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Root>();
            builder.Entity<Intermediate>(b =>
            {
                b.Property(x => x.RecordType).HasConversion<string>();
            });
            builder.Entity<Leaf>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Password123;Database=npgsqlpoc");
        }
    }
}
