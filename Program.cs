using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pgsql_poc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ctx = new PocContext();
            if (!ctx.Database.GetAppliedMigrations().Any())
            {
                ctx.Database.Migrate();
            }

            var results = await RootQuery(ctx, 7)
                .Union(IntermediateQuery(ctx, 7))
                .ToArrayAsync();

            Console.WriteLine("It worked!");
        }

        private static IQueryable<Leaf> RootQuery(PocContext context, int id)
        {
            return WrapQuery(
                context.Set<Intermediate>()
                    .Where(x => x.Id == id)
                    .Where(x => x.RecordType == IntermediateRecordType.FarType)
                    .SelectMany(x => x.Root.LeafLinks),
                DateTime.Now);
        }

        private static IQueryable<Leaf> IntermediateQuery(PocContext context, int id)
        {
            return WrapQuery(
                context.Set<Intermediate>()
                    .Where(x => x.Id == id)
                    .Where(x => x.RecordType == IntermediateRecordType.NearType)
                    .SelectMany(x => x.LeafLinks),
                DateTime.Now);
        }

        private static IQueryable<Leaf> WrapQuery<T>(IQueryable<T> query, DateTime asOf)
            where T : LeafLink
        {
            return query
                .Where(x => x.Effective <= asOf)
                .OrderByDescending(x => x.Effective)
                .Take(1)
                .Select(x => x.Leaf);
        }
    }
}
