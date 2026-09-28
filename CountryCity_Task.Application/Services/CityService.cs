using CountryCity_Task.Application.Dto.CityDto;
using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Application.Interfaces;
using CountryCity_Task.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Services
{
    public class CityService : ICityService
    {
        public readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CityDto> CreateAsync(CreateCityDto dto)
        {

            var city = new City
            {
                Name = dto.Name,
                CountryId = dto.CountryId
            };

            await _cityRepository.CreateAsync(city);

            await _unitOfWork.SaveChangesAsync();


            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
            };
        }
        public async Task<CityDto?> GetByIdAsync(int id)
        {
            var city = await _cityRepository.GetByIdIncludeCountryAsync(id);
            if (city == null)
                return null;
            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CountryName = city.Country?.Name ?? string.Empty,
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateCityDto dto)
        {
            var existingCity = await _cityRepository.GetByIdAsync(id);

            if (existingCity == null)
                return false;


            existingCity.Name = dto.Name;

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);

            if (city == null)
                return false;

            _cityRepository.Delete(city);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedResult<CityDto>> GetPagedAsync(string? name, PaginationRequest pagination)
        {
            var result = await _cityRepository.GetPagedAsync(
                name,
                pagination);

            return new PaginatedResult<CityDto>
            {
                Items = result.Items.Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryName = c.Country?.Name ?? string.Empty,
                }).ToList(),

                TotalCount = result.TotalCount,

                PageNumber = result.PageNumber,

                PageSize = result.PageSize
            };
        }
        public async Task<PaginatedResult<CityDto>> GetPagedByCountryIdAsync(int countryId, PaginationRequest pagination)
        {
            var result = await _cityRepository.GetPagedByCountryIdAsync(
                countryId,
                pagination);

            return new PaginatedResult<CityDto>
            {
                Items = result.Items.Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryName = c.Country?.Name ?? string.Empty,

                }).ToList(),

                TotalCount = result.TotalCount,

                PageNumber = result.PageNumber,

                PageSize = result.PageSize
            };
        }

    }
}

