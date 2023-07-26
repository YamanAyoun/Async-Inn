namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmenity
    {
        // Create
        Task<Amenity> Create(Amenity amenity);
        
        // GET All
        Task<List<Amenity>> GetAmenities();
        
        // GET by ID
        Task<Amenity> GetAmenity(int id);
        
        // UPDATE
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);
        
        // DELET by ID
        Task Delete(int id);
    }
}
