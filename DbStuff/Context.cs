using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DemoECS.Component;

namespace DemoECS.DbStuff
{
    public class Context : DbContext
    {
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Cord> Cords { get; set; }
        public DbSet<Persistence> Persistences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("User ID=bfalk;Host=localhost;Port=5432;Database=demo_ecs;");
    }
}