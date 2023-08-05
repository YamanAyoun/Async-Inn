using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
    public class HotelServices : IHotel
    {
        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.hotels.Select(x => new HotelDTO
            {
                Id = x.Id,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.HotelRooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = new RoomDTO
                    {
                        Id = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenities.Select(x => new AmenityDTO
                        {
                            Id = x.AmenityID,
                            Name = x.Amenity.Name
                        }).ToList()

                    }
                }).ToList()
            }).ToListAsync();
        }
        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.hotels.Select(x => new HotelDTO
            {
                Id = x.Id,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                City = x.City,
                State = x.State,
                
                Rooms = x.HotelRooms.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    
                    RoomID = x.RoomID,
                    Room = new RoomDTO
                    {
                        Id = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenities.Select(x => new AmenityDTO
                        {
                            Id = x.AmenityID,
                            Name = x.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await _context.hotels.FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
