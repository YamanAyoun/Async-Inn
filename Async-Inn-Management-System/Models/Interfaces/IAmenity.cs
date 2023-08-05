using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        // Create
        Task<Amenity> Create(AmenityDTO amenity);
        
        // GET All
        Task<List<AmenityDTO>> GetAmenities();
        
        // GET by ID
        Task<AmenityDTO> GetAmenity(int id);
        
        // UPDATE
        Task<Amenity> UpdateAmenity(int id, AmenityDTO amenity);
        
        // DELET by ID
        Task Delete(int id);
    }
}
