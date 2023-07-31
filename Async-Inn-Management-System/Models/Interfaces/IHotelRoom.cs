using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);
        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task Delete(int hotelId, int roomId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom);
        Task DeleteRoomFromHotel(int roomId, int hotelId);
    }
}
