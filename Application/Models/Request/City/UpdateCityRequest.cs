using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.City
{
    public class UpdateCityRequest
    {
        #region BasicAttributes
        public int Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        #endregion

        #region Constructors
        public UpdateCityRequest(int id, string name, string uF)
        {
            Id = id;
            Name = name;
            UF = uF;
        }
        #endregion
    }
}
