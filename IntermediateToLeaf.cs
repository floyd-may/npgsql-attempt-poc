namespace pgsql_poc
{
    public sealed class IntermediateToLeaf : LeafLink
    {
        public int IntermediateId { get; set; }
        public Intermediate Intermediate { get; set; }
    }
}
