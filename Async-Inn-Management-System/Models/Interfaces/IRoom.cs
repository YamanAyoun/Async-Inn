using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IRoom
    {
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<Room> Create(RoomDTO room);
        Task Delete(int id);
        Task<Room> UpdateRoom(int id, RoomDTO room);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
