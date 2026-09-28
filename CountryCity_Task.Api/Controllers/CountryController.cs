using CountryCity_Task.Application.Dto.CountryDto;
using CountryCity_Task.Application.Dto.Pagination;
using CountryCity_Task.Application.Interfaces;
using CountryCity_Task.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryCity_Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost]
        [Route("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDto country)
        {
            if (country == null)
            {
                return BadRequest("Country is null.");
            }
            await _countryService.CreateAsync(country);
            return Ok();
        }

        [HttpGet]
        [Route("GetCountryById/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _countryService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountries(string? name, string? code, int pageNumber = 1, int pageSize = 10)
        {
            var pagination = new PaginationRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var countries = await _countryService.GetPagedAsync(
                name,
                code,
                pagination);

            return Ok(countries);
        }

        [HttpPut]
        [Route("UpdateCountry/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDto dto)
        {
            if (dto == null)
                return BadRequest();

            var updated = await _countryService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await _countryService.DeleteAsync(country.Id);
            return NoContent();
        }
    }
}
