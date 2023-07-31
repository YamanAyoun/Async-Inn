using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            return await _context.HotelRooms
                
                .Select(h => new HotelRoomDTO
                {
                    HotelID = h.HotelID,
                    Rate = h.Rate,
                    RoomID = h.RoomID,
                    RoomNumber = h.RoomNumber,
                    Room = new RoomDTO
                    {
                        Id = h.Room.Id,
                        Name = h.Room.Name,
                        Layout = h.Room.Layout,
                        Amenities = h.Room.RoomAmenities
                            .Select(a => new AmenityDTO
                            {
                                Id = a.RoomID,
                                Name = a.Amenity.Name
                            }).ToList()
                    }
                })
                .ToListAsync();
            
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomId)
        {
            return await _context.HotelRooms
                .Select(x => new HotelRoomDTO
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

                }).FirstOrDefaultAsync();
        }

        public async Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoomDTO hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


        }

        public async Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {

            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task DeleteRoomFromHotel(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(h => h.HotelID == hotelId && h.RoomID == roomId)
            .FirstAsync();

            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
