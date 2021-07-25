using System.Collections.Generic;

namespace pgsql_poc
{
    public sealed class Intermediate
    {
        public int Id { get; set; }

        public IntermediateRecordType RecordType { get; set; }

        public Root Root { get; set; }

        public ICollection<IntermediateToLeaf> LeafLinks { get; set; }
    }
}
