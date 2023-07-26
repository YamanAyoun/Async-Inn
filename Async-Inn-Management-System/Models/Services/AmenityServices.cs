using Async_Inn_Management_System.Data;
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
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.amenities.FindAsync(id);
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
