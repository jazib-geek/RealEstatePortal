using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _context;
        public PropertyRepository(RealEstateContext context) => _context = context;

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _context.Properties.AsNoTracking().ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            return await _context.Properties.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Property> CreateAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property?> UpdateAsync(Property property)
        {
            var existing = await _context.Properties.FindAsync(property.Id);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(property);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Property property)
        {
            if (property == null)
                return false;

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
