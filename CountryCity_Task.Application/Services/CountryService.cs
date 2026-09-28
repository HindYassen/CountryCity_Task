using CountryCity_Task.Application.Dto.CityDto;
using CountryCity_Task.Application.Dto.CountryDto;
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
    public class CountryService : ICountryService
    {
        public readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CountryDto> CreateAsync(CreateCountryDto dto)
        {
            var country = new Country
            {
                Name = dto.Name,
                Code = dto.Code
            };

            await _countryRepository.CreateAsync(country);

            await _unitOfWork.SaveChangesAsync();


            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Code = country.Code
            };
        }
        public async Task<CountryDto?> GetByIdAsync(int id)
        {
            await _countryRepository.GetByIdAsync(id);
            var country = await _countryRepository.GetByIdAsync(id);
            if (country == null)
                return null;
            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Code = country.Code
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateCountryDto dto)
        {
            var existingCountry = await _countryRepository.GetByIdAsync(id);

            if (existingCountry == null)
                return false;


            existingCountry.Name = dto.Name;
            existingCountry.Code = dto.Code;

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
                return false;

            _countryRepository.Delete(country);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedResult<CountryDto>> GetPagedAsync(string? name, string? code, PaginationRequest pagination)
        {
            var result = await _countryRepository.GetPagedAsync(
                name,
                code,
                pagination);

            return new PaginatedResult<CountryDto>
            {
                Items = result.Items.Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code
                }).ToList(),

                TotalCount = result.TotalCount,

                PageNumber = result.PageNumber,

                PageSize = result.PageSize
            };
        }
    }
}
