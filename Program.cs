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
        private static World World = new World();
        private const string world_state_file_path = "world-state.txt";

        static void Main(string[] args)
        {
            // LoadWorld();
            WorldSerializer.Load(World);
            Console.WriteLine("We loaded the world!");

            Console.WriteLine("All known by a name:");
            foreach(var entity in World.GetEntities().With<Identity>().AsSet().GetEntities())
            {
                Console.WriteLine(entity.Get<Identity>().Name);
            }

            WorldSerializer.Serialze(World);
            Console.WriteLine("We saved the world!");
            // SaveWorld();
        }

        private static void LoadWorld()
        {
            ISerializer serializer = new TextSerializer();

            using (Stream stream = File.OpenRead(world_state_file_path))
            {
                World = serializer.Deserialize(stream);
            }
        }

        private static void SaveWorld()
        {
            ISerializer serializer = new TextSerializer();

            using (Stream stream = File.Create(world_state_file_path))
            {
                serializer.Serialize(stream, World);
            }
        }
    }
}