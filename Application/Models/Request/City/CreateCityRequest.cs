using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request.City
{
    public class CreateCityRequest
    {
        #region BasicAttributes
        public string Name { get; set; }
        public string UF { get; set; }
        #endregion

        #region Constructors
        public CreateCityRequest(string name, string uF)
        {
            Name = name;
            UF = uF;
        }
        #endregion
    }
}
