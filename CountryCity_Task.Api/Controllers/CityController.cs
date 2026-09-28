using CountryCity_Task.Application.Dto.CityDto;
using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Application.Interfaces;
using CountryCity_Task.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryCity_Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ICountryRepository _countryRepository;
        public CityController(ICityService cityService, ICountryRepository countryRepository)
        {
            _cityService = cityService;
            _countryRepository = countryRepository;
        }
        [HttpPost]
        [Route("CreateCity")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDto city)
        {
            var country = await _countryRepository.GetByIdAsync(city.CountryId);

            if (country == null)
            {
                return NotFound("No Country with this Id");

            }
            await _cityService.CreateAsync(city);
            return Ok();
        }

        [HttpGet]
        [Route("GetCityById/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities(string? name, int pageNumber = 1, int pageSize = 10)
        {
            var pagination = new PaginationRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var cities = await _cityService.GetPagedAsync(
                name,
                pagination);

            return Ok(cities);
        }

        [HttpGet]
        [Route("GetCitiesByCountry/{countryId}")]
        public async Task<IActionResult> GetCitiesByCountryId(int countryId, int pageNumber = 1, int pageSize = 10)
        {
            var pagination = new PaginationRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var cities = await _cityService.GetPagedByCountryIdAsync(
                countryId,
                pagination);

            return Ok(cities);
        }

        [HttpPut]
        [Route("UpdateCity/{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityDto dto)
        {
            if (dto == null)
                return BadRequest();

            var updated = await _cityService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound("No City with this Id");

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
                return BadRequest();

            await _cityService.DeleteAsync(city.Id);
            return NoContent();
        }
    }
}

