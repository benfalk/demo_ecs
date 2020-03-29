using DemoECS;

namespace DemoECS.Component
{
    public class Cord : IPersistable
    {
        public int Id { get; set; }
        public Persistence Persistence { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}