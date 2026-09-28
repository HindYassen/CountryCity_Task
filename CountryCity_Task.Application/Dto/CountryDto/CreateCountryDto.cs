using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Dto.CountryDto
{
    public class CreateCountryDto
    {
        [Required(ErrorMessage = "Country name is required.")]
        [StringLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Country code is required.")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Country code must be between 2 and 3 characters.")]
        public string Code { get; set; } = null!;
    }
}
