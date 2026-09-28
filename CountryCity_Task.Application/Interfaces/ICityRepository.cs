using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<PaginatedResult<City>> GetPagedAsync(string? name, PaginationRequest paginationRequest);
        Task<PaginatedResult<City>> GetPagedByCountryIdAsync(int countryId, PaginationRequest paginationRequest);
        Task<City?> GetByIdIncludeCountryAsync(int id);
    }
}
