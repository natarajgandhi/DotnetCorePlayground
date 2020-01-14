using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyAPI.Data
{
    public class HotelContext : DbContext
    {
        private readonly IConfiguration _config;

        public HotelContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("HotelDataBase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(new { LocationId = 55, Name = "Philly" });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 22, Name = "Royal TN", LocationId =  55, Cuisine = "Indian"  });
            modelBuilder.Entity<Location>().HasData(new { LocationId = 56, Name = "Louisville" });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 23, Name = "Ashoka", LocationId = 56, Cuisine = "Italian" });
            modelBuilder.Entity<Location>().HasData(new { LocationId = 100, Name = "Alaska" });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 1, Name = "Chill Thund", LocationId = 100, Cuisine = "Colombian" });
        }


    }
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Cuisine { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
