using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotel
    {
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<Hotel> Create(Hotel hotel);
        Task Delete(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
    }
}
