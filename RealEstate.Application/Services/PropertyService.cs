using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Domain;

namespace RealEstate.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var props = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(props);
        }

        public async Task<PropertyDto> GetByIdAsync(int id)
        {
            var prop = await _repo.GetByIdAsync(id);
            return _mapper.Map<PropertyDto>(prop);
        }

        public async Task<PropertyDto> CreateAsync(PropertyDto dto)
        {
            var prop = _mapper.Map<Property>(dto);
            var created = await _repo.CreateAsync(prop);
            return _mapper.Map<PropertyDto>(created);
        }

        public async Task<PropertyDto> UpdateAsync(int id, PropertyDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            dto.Id = id;
            var updated = await _repo.UpdateAsync(existing);

            return _mapper.Map<PropertyDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return false;

            return await _repo.DeleteAsync(existing);
        }

    }
}
