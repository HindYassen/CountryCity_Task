using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Application.Interfaces;
using CountryCity_Task.Domain;
using CountryCity_Task.Infrastructure.Persistence;
using CountryCity_Task.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CountryCity_Task.Infrastructure.Repositories
{
    public class CountryRepository
        : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<PaginatedResult<Country>> GetPagedAsync(string? name, string? code, PaginationRequest pagination)
        {
            var query = _dbSet
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c =>
                    c.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(code))
            {
                query = query.Where(c =>
                    c.Code == code);
            }

            var totalCount = await query.CountAsync();

            var countries = await query
                .OrderBy(c => c.Name)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginatedResult<Country>
            {
                Items = countries,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
    }
}