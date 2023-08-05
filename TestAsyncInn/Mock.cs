using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestAsyncInn
{
    public abstract class Mock : IDisposable
    {

        private readonly SqliteConnection _connection;

        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { Name = "Test", Layout = 1 };
            _db.rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.Id); 
            return room;
        }


        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel()
            {
                Name = "Test",
                StreetAddress = "Test",
                City = "Test",
                State = "Test",
                Country = "Test",
                Phone = 0
            };

            _db.hotels.Add(hotel);
            await _db.SaveChangesAsync();

            //Assert.NotEqual(0, hotel.Id);

            return hotel;


        }


        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity { Name = "Test" };
            _db.amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.Id); 
            return amenity;
        }



    }
}