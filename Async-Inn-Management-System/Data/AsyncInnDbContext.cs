using Async_Inn_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> hotels { get; set; }

        public DbSet<Room> rooms { get; set; } 

        public DbSet<Amenity> amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel Amman", StreetAddress = "s-077", City = "Amman", State = "Amman", Country = "Jordan", Phone = 0784234 },
                new Hotel { Id = 2, Name = "Hotel Aqaba", StreetAddress = "a-137", City = "Aqaba", State = "Aqaba", Country = "Jordan", Phone = 0742342 },
                new Hotel { Id = 3, Name = "Hotel Dead Sea", StreetAddress = "c-237", City = "Dead Sea", State = "Deadsea", Country = "Jordan", Phone = 0785483 }
            );


            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Stander Room", Layout = 1 },
                new Room { Id = 2, Name = "Suite Room", Layout = 2 },
                new Room { Id = 3, Name = "Executive suite Room", Layout = 3 }
            );


            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "Stander Amenity" },
                new Amenity { Id = 2, Name = "Medium Amenity" },
                new Amenity { Id = 3, Name = "Superior Amenity" }
            );
        }
    }
}
