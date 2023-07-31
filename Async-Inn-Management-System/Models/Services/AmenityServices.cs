using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Services
{
    public class AmenityServices : IAmenity
    {

        private readonly AsyncInnDbContext _context;

        public AmenityServices(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Create(AmenityDTO amenity)
        {
            Amenity newAmenity = new Amenity
            {
                Id = amenity.Id,
                Name = amenity.Name,
            };
            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newAmenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.amenities.Select(x => new AmenityDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            AmenityDTO amenity = await _context.amenities
             .Select(amenity => new AmenityDTO
             {
                 Id = amenity.Id,
                 Name = amenity.Name,
                 }).FirstOrDefaultAsync(s => s.Id == id);

            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
