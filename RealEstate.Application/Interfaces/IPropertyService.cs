using RealEstate.Application.DTOs;

namespace RealEstate.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto> GetByIdAsync(int id);
        Task<PropertyDto> CreateAsync(PropertyDto dto);
        Task<PropertyDto> UpdateAsync(int id, PropertyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
