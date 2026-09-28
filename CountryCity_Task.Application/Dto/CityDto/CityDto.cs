using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryCity_Task.Application.Dto.CityDto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string CountryName { get; set; } = string.Empty;
    }
}
