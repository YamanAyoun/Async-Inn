using Async_Inn_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> hotels { get; set; }

        public DbSet<Room> rooms { get; set; } 

        public DbSet<Amenity> amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaims = permissions.Select(permission =>
              new IdentityRoleClaim<string>
              {
                  Id = nextId++,
                  RoleId = role.Id,
                  ClaimType = "permissions", 
                  ClaimValue = permission
              }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
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

            SeedRole(modelBuilder, "Admin", "create", "update", "delete");
            SeedRole(modelBuilder, "User", "create", "update");

            modelBuilder.Entity<RoomAmenity>().HasKey(
                roomAmenities => new { roomAmenities.RoomID, roomAmenities.AmenityID });

            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRooms => new { hotelRooms.HotelID, hotelRooms.RoomID });
        }
    }
}
