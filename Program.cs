using System;
using System.IO;
using DefaultEcs;
using DefaultEcs.Serialization;
using DemoECS.Component;
using DemoECS.DbStuff;

namespace demo_ecs
{
    class Program
    {
        private static World world = new World();
        private const string world_state_file_path = "world-state.txt";
        private static CompenentSerializer Serializer = new CompenentSerializer();

        static void Main(string[] args)
        {
            LoadWorld();

            foreach(Entity entity in world)
            {
                if(!entity.Has<Persistence>())
                {
                    entity.Set<Persistence>(new Persistence());
                }
            }

            Console.WriteLine("All known by a name:");
            foreach(var entity in world.GetEntities().With<Identity>().AsSet().GetEntities())
            {
                Console.WriteLine(entity.Get<Identity>().Name);
                entity.ReadAllComponents(Serializer);
            }

            Serializer.Context.SaveChanges();

            SaveWorld();
        }

        private static void LoadWorld()
        {
            ISerializer serializer = new TextSerializer();

            using (Stream stream = File.OpenRead(world_state_file_path))
            {
                world = serializer.Deserialize(stream);
            }
        }

        private static void SaveWorld()
        {
            ISerializer serializer = new TextSerializer();

            using (Stream stream = File.Create(world_state_file_path))
            {
                serializer.Serialize(stream, world);
            }
        }
    }
}