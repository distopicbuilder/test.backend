using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.People
{
    public class GetAllPeopleResponse
    {
        public List<PeopleDto>? Peoples { get; set; }
    }
}
