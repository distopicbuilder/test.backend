using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitys;

namespace Application.Models.Request.People
{
    public class CreatePeopleRequest
    {
        #region BaseAttributes
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        #endregion 

        #region Relations 
        public int CityId { get; set; }
        #endregion

        #region BasicAttributes
        public CreatePeopleRequest(string name, string cPF, int idade, int cityId)
        {
            Name = name.Trim();
            CPF = cPF.Trim();
            Idade = idade;
            CityId = cityId;
        }
        #endregion
    }
}
