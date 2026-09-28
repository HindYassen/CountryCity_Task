using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Application.Interfaces;
using CountryCity_Task.Domain;
using CountryCity_Task.Infrastructure.Persistence;
using CountryCity_Task.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace CountryCity_Task.Infrastructure.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public async Task<City?> GetByIdIncludeCountryAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<PaginatedResult<City>> GetPagedAsync(string? name, PaginationRequest pagination)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(c => c.Country)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c =>
                    c.Name.Contains(name));
            }

            var totalCount = await query.CountAsync();

            var cities = await query
                .OrderBy(c => c.Name)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginatedResult<City>
            {
                Items = cities,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
        public async Task<PaginatedResult<City>> GetPagedByCountryIdAsync(int countryId, PaginationRequest pagination)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(c => c.Country)
                .AsQueryable();

            query = query.Where(c => c.CountryId == countryId);

            var totalCount = await query.CountAsync();

            var cities = await query
                .OrderBy(c => c.Name)
                .Skip(
                    (pagination.PageNumber - 1)
                    * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginatedResult<City>
            {
                Items = cities,
                TotalCount = totalCount,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }
    }
}
