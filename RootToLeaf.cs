using System;

namespace pgsql_poc
{
    public sealed class RootToLeaf : LeafLink
    {
        public int RootId { get; set; }
        public Root Root { get; set; }
    }
}
