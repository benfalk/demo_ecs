using System.Collections.Generic;
using System.Linq;
using DefaultEcs.Serialization;
using DemoECS.Component;
using Microsoft.EntityFrameworkCore;

namespace DemoECS.DbStuff
{
    static class EntityExtensions
    {
        public static T TryGet<T>(this DefaultEcs.Entity entity, T defaltValue = null)
            where T : class
            => entity.Has<T>() ? entity.Get<T>() : defaltValue;
    }

    static class ICollectionExtensions
    {
        public static void ApplyToEntity<T>(this ICollection<T> collection, DefaultEcs.Entity entity)
        {
            var comp = collection.FirstOrDefault();
            if (comp != null)
            {
                entity.Set(comp);
            }
        }
    }

    public class WorldSerializer
    {
        private Context Context = new Context();

        private CompenentSerializer CompenentSerializer;

        WorldSerializer()
        {
            CompenentSerializer = new CompenentSerializer(Context);
        }

        public static void Serialze(DefaultEcs.World world)
        {
            var serializer = new WorldSerializer();
            foreach(var entity in world)
            {
                entity.ReadAllComponents(serializer.CompenentSerializer);
            }
            serializer.Context.SaveChanges();
        }

        public static void Load(DefaultEcs.World world)
        {
            var serializer = new WorldSerializer();

            var persistences =
                serializer.Context.Persistences
                    .Include(x => x.Cords)
                    .Include(x => x.Identities)
                    .ToList();
            
            foreach(var persistence in persistences)
            {
                var entity = world.CreateEntity();
                entity.Set(persistence);
                persistence.Cords.ApplyToEntity(entity);
                persistence.Identities.ApplyToEntity(entity);
            }
        }
    }

    class CompenentSerializer : IComponentReader
    {
        private Context Context;

        public CompenentSerializer(Context context)
        {
            Context = context;
        }

        public void OnRead<T>(ref T component, in DefaultEcs.Entity componentOwner)
        {
            var persistence = componentOwner.TryGet<Persistence>();
            
            if (!(persistence is Persistence p))
            {
                return;
            }

            if (p.PersistenceId == default)
            {
                Context.Persistences.Add(p);
            }

            if (!(component is IPersistable persistable))
            {
                return;
            }

            persistable.Persistence = persistence;
            if (persistable.Id == default)
            {
                Context.Add(component);
            }
            else
            {
                Context.Update(component);
            }
        }
    }
}