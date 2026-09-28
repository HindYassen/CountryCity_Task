using CountryCity_Task.Application.Dto.CityDto;
using CountryCity_Task.Application.Dto.Pagination;

namespace CountryCity_Task.Application.Interfaces
{
    public interface ICityService
    {
        Task<PaginatedResult<CityDto>> GetPagedAsync(string? name, PaginationRequest pagination);
        Task<PaginatedResult<CityDto>> GetPagedByCountryIdAsync(int countryId, PaginationRequest pagination);
        Task<CityDto?> GetByIdAsync(int id);
        Task<CityDto> CreateAsync(CreateCityDto dto);
        Task<bool> UpdateAsync(int id, UpdateCityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
