using CountryCity_Task.Application.Dto.CountryDto;
using CountryCity_Task.Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Interfaces
{
    public interface ICountryService
    {
        Task<PaginatedResult<CountryDto>> GetPagedAsync(string? name, string? code, PaginationRequest pagination);
        Task<CountryDto?> GetByIdAsync(int id);
        Task<CountryDto> CreateAsync(CreateCountryDto dto);
        Task<bool> UpdateAsync(int id, UpdateCountryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
