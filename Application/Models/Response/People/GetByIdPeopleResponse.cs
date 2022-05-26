using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response.People
{
    public class GetByIdPeopleResponse
    {
        public PeopleDto People{ get; set; }
        public GetByIdPeopleResponse(PeopleDto people)
        {
            People = people;
        }
    }
}
