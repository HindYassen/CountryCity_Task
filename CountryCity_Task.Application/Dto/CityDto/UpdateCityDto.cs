using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Dto.CityDto
{
    public class UpdateCityDto
    {
        [Required(ErrorMessage = "City name is required.")]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
