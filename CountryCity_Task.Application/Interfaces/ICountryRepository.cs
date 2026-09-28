using CountryCity_Task.Application.Dto.CountryDto;
using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<PaginatedResult<Country>> GetPagedAsync(string? name, string? code, PaginationRequest paginationRequest);
    }
}
