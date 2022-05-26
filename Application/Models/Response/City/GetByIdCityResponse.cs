using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.City
{
    public class GetByIdCityResponse
    {
        public CityDto City{ get; set; }
        public GetByIdCityResponse(CityDto city)
        {
            City = city;
        }
    }
}
