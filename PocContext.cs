using Microsoft.EntityFrameworkCore;

namespace pgsql_poc
{
    public sealed class PocContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Root>();
            builder.Entity<Intermediate>();
            builder.Entity<Leaf>();
        }
    }
}