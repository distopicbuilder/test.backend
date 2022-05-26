using Application.Models.Dtos;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.City
{
    public class GetAllCityResponse
    {
        public List<CityDto>? Cities { get; set; }
    }
}
