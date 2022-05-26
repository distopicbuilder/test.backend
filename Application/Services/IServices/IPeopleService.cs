using Application.Models.Request.People;
using Application.Models.Response.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    public interface IPeopleService
    {
        Task<GetAllPeopleResponse> GetAllAsync();
        Task<GetByIdPeopleResponse> GetByIdAsync(int idCity);
        Task<CreatePeopleResponse> CreateAsync(CreatePeopleRequest request);
        Task<UpdatePeopleResponse> UpdateAsync(UpdatePeopleRequest request);
        Task<DeletePeopleResponse> DeleteByIdAsync(int idPeople);
    }
}
