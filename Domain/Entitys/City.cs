using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class City : BaseEntity
    {
        #region BaseAttributes
        [StringLength(200)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [StringLength(2)]
        [Required(AllowEmptyStrings = false)]
        public string UF { get; set; }
        #endregion

        #region Constructors
        public City() { }
        public City(string name, string uF)
        {
            Validation(name, uF);
            Name = name.Trim();
            UF = uF.Trim();
        }
        #endregion

        #region HelpersDML
        public void Update(string name, string uF)
        {
            Validation(name, uF);
            Name = name.Trim();
            UF = uF.Trim();
        }
        #endregion

        #region Validations
        public void Validation(string name, string uF)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(uF))
                throw new ArgumentException("Não pode haver atributos nullos.");
            if (name.Length > 200)
                throw new ArgumentException("Somente 200 caracteres são permitidos para nome.");
            if (uF.Length > 2)
                throw new ArgumentException("Somente 2 caracteres são permitidos para estado");
        }
        #endregion
    }
}
