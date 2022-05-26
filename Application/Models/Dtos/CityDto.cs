using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class CityDto
    {
        #region BasicAttributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        #endregion

        #region Constructors
        public CityDto(int id, string name, string uF)
        {
            Id = id;
            Name = name;
            UF = uF;
        }
        #endregion

        #region Operator
        public static explicit operator CityDto(City city)
        {
            return new CityDto(city.Id, city.Name, city.UF);
        }
        #endregion
    }
}
