namespace pgsql_poc
{
    public sealed class IntermediateToLeaf
    {
        public int Id { get; set; }
        public int IntermediateId { get; set; }
        public Intermediate Intermediate { get; set; }

        public int LeafId { get; set; }
        public Leaf Leaf { get; set; }
    }
}