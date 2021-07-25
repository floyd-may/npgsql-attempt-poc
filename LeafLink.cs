using System;
using NodaTime;

namespace pgsql_poc
{
    public abstract class LeafLink
    {
        public int Id { get; set; }

        public int LeafId { get; set; }
        public Leaf Leaf { get; set; }

        public LocalDate Effective { get; set; }
    }
}
