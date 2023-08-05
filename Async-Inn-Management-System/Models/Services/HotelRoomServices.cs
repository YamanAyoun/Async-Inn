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
            var hotelrooms = await _context.HotelRooms
                .Where(h => h.HotelID == hotelId)
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
            return hotelrooms;

        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomId)
        {
            var hotelRoom = await _context.HotelRooms
                .Where(hr => hr.HotelID == hotelId && hr.RoomNumber == roomId)
                .Select(hr => new HotelRoomDTO
                {
                    RoomID = hr.RoomID,
                    HotelID = hr.HotelID,
                    Rate = hr.Rate,
                    RoomNumber = hr.RoomNumber,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.Id,
                        Layout = hr.Room.Layout,
                        Name = hr.Room.Name,
                        Amenities = hr.Room.RoomAmenities
                            .Select(a => new AmenityDTO
                            {
                                Id = a.RoomID,
                                Name = a.Amenity.Name
                            }).ToList()
                    }
                }).FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomId);

            return hotelRoom;
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
