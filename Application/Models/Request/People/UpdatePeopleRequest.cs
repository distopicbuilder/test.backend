using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.People
{
    public class UpdatePeopleRequest
    {
        #region BaseAttributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        #endregion 

        #region Relations 
        public int CityId { get; set; }
        #endregion

        #region Constructors
        public UpdatePeopleRequest(int id,string name, string cPF, int idade, int cityId)
        {
            Id = id;
            Name = name.Trim();
            CPF = cPF.Trim();
            Idade = idade;
            CityId = cityId;
        }
        #endregion
    }
}
