using System;
using System.Reflection.Metadata;
using MapiServerCS.models;
using Microsoft.EntityFrameworkCore;

namespace MapiServerCS.db
{
	public class MapiContext:DbContext
	{
		public DbSet<Map> Maps { get; set; }
        public DbSet<Location> Locations { get; set; }

        public MapiContext(DbContextOptions<MapiContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString:
               "Server=localhost;Port=55000;User Id=postgres;Password=postgrespw;Database=mapiCS;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}

