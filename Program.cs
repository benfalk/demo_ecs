﻿using System;
using System.IO;
using DefaultEcs;
using DefaultEcs.Serialization;
using DemoECS.Component;

namespace demo_ecs
{
    class Program
    {
        private static World world = new World();
        private static string world_state_file_path = "world-state.txt";

        static void Main(string[] args)
        {
            LoadWorld();

            Console.WriteLine("All known by a name:");
            foreach(var entity in world.GetEntities().With<Identity>().AsSet().GetEntities())
            {
                Console.WriteLine(entity.Get<Identity>().Name);
            }

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