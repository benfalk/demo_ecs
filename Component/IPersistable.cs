namespace DemoECS.Component
{
    public interface IPersistable
    {
        Persistence Persistence { get; set; }
        int Id { get; set; }
    }
}