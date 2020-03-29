using DemoECS;

namespace DemoECS.Component
{
    public class Identity : IPersistable
    {
        public int IdentityId { get; set; }
        public Persistence Persistence { get; set; }
        public string Name { get; set; }
    }
}