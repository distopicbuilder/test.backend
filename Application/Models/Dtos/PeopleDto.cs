using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos
{
    public class PeopleDto
    {
        #region BaseAttributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        #endregion

        #region Relations 
        public int CityId { get; set; }
        public City City { get; set; }
        #endregion

        #region Constructors
        public PeopleDto(int id, string name, string cPF, int idade, City city)
        {
            Id = id;
            Name = name;
            CPF = cPF;
            Idade = idade;
            City = city;
            CityId = city.Id;
        }
        #endregion

        #region Operator
        public static explicit operator PeopleDto(People people)
        {
            return new PeopleDto(people.Id, people.Name, people.CPF, people.Idade, people.City);
        }
        #endregion
    }
}
