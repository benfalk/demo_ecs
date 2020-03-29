using System.Collections.Generic;

namespace DemoECS.Component
{
    public class Persistence
    {
        public int PersistenceId { get; set; }
        public virtual ICollection<Cord> Cords { get; set; } = new HashSet<Cord>();
        public virtual ICollection<Identity> Identities { get; set; } = new HashSet<Identity>();
    }
}