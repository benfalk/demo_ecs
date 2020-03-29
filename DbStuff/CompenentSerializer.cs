using DefaultEcs.Serialization;
using DemoECS.Component;

namespace DemoECS.DbStuff
{
    public static class EntityExtensions
    {
        public static T TryGet<T>(this DefaultEcs.Entity entity, T defaltValue = null)
            where T : class
            => entity.Has<T>() ? entity.Get<T>() : defaltValue;
    }

    public class CompenentSerializer : IComponentReader
    {
        public Context Context = new Context();
        public void OnRead<T>(ref T component, in DefaultEcs.Entity componentOwner)
        {
            var persistence = componentOwner.TryGet<Persistence>();
            
            if (persistence is Persistence p)
            {
                Context.Persistences.Add(p);
            }
            else
            {
                return;
            }

            if (component is IPersistable persistable)
            {
                persistable.Persistence = persistence;
            }
            else
            {
                return;
            }

            Context.Add(component);
        }
    }
}