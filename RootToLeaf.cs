namespace pgsql_poc
{
    public sealed class RootToLeaf
    {
        public int Id { get; set; }
        public int RootId { get; set; }
        public Root Root { get; set; }

        public int LeafId { get; set; }
        public Leaf Leaf { get; set; }
    }
}