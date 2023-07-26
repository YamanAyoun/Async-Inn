namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> UpdateHotelRoom(HotelRoom hotelRoom);
        Task Delete(int hotelId, int roomId);

        Task<HotelRoom> AddRoomToHotel(int hotelId, HotelRoom hotelRoom);
        Task DeleteRoomFromHotel(int roomId, int hotelId);
    }
}
