using System.Collections.Generic;

namespace pgsql_poc
{
    public sealed class Root
    {
        public int Id { get; set; }

        public ICollection<RootToLeaf> LeafLinks { get; set; }
        public ICollection<Intermediate> Intermediates { get; set; }
    }
}
