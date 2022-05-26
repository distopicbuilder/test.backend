using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class People : BaseEntity
    {
        #region BaseAttributes
        [StringLength(300)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [StringLength(11)]
        [Required(AllowEmptyStrings = false)]
        public string CPF { get; set; }
        [MinLength(0)]
        [Required]
        public int Idade { get; set; }
        #endregion 

        #region Relations 
        public City City { get; set; }
        #endregion

        #region Constructors
        public People() { }
        public People(string name, string cPF, int idade, City city)
        {
            Validation(name, cPF, idade, city);
            Name = name.Trim();
            CPF = cPF.Trim();
            Idade = idade;
            City = city;
        }
        #endregion

        #region HelpersDML
        public void Update(string name, string cPF, int idade, City city)
        {
            Validation(name, cPF, idade, city);
            Name = name.Trim();
            CPF = cPF.Trim();
            Idade = idade;
            City = city;
        }
        #endregion

        #region Validations
        public void Validation(string name, string cpf, int idade, City city)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(cpf) || city == null)
                throw new ArgumentException("Não pode haver atributos nullos.");
            if (name.Length > 300)
                throw new ArgumentException("Somente 300 caracteres são permitidos para nome.");
            if (cpf.Length > 11)
                throw new ArgumentException("Somente 11 caracteres são permitidos para estado");
            if(idade == 0 || idade > 100)
                throw new ArgumentException("Idade deve estar entre 0 e 100.");

        }
        #endregion
    }
}
