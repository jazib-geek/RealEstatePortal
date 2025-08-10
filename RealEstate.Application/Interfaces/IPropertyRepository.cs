using RealEstate.Domain;

namespace RealEstate.Application.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(int id);
        Task<Property> CreateAsync(Property property);
        Task<Property?> UpdateAsync(Property property);
        Task<bool> DeleteAsync(Property property);
    }
}
