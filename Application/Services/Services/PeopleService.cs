using Application.Models.Dtos;
using Application.Models.Request.People;
using Application.Models.Response.People;
using Application.Services.IServices;
using Domain.Entitys;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly ICityService _cityService;

        #region Const
        private const string EMPTY_ERROR = "Objeto pessoa não pode ser null.";
        private const string SEARCH_NULL_ERROR = "Nenhuma pessoa encontrada.";
        private const string NOT_FOUND_CITY = "Cidade não encontrada.";
        #endregion

        #region Constructors
        public PeopleService(ApplicationDbContext applicationDbContext, ICityService cityService)
        {
            _ApplicationDbContext = applicationDbContext;
            _cityService = cityService;
        }
        #endregion

        public async Task<GetAllPeopleResponse> GetAllAsync()
        {
            var entity = await _ApplicationDbContext
                                .People
                                .Include(nameof(People.City))
                                .AsNoTracking()
                                .ToListAsync();

            return new GetAllPeopleResponse()
            {
                Peoples = entity != null ? entity.Select(a => (PeopleDto)a).ToList() : new List<PeopleDto>()
            };
        }
        public async Task<GetByIdPeopleResponse> GetByIdAsync(int idPeople)
        {
            var entity = await CheckAndReturnPeople(idPeople);

            var response = new GetByIdPeopleResponse((PeopleDto)entity);

            return response;
        }
        public async Task<CreatePeopleResponse> CreateAsync(CreatePeopleRequest request)
        {
            CheckNullObject(request);

            var city = await CheckAndReturnCity(request.CityId);
            People newPeople = new(request.Name, request.CPF, request.Idade, city);

            _ApplicationDbContext.People.Add(newPeople);
            await _ApplicationDbContext.SaveChangesAsync();

            return new CreatePeopleResponse() { Id = newPeople.Id };
        }
        public async Task<UpdatePeopleResponse> UpdateAsync(UpdatePeopleRequest request)
        {
            CheckNullObject(request);
           
            var entity = await CheckAndReturnPeople(request.Id);
            var city = await CheckAndReturnCity(request.CityId);

            entity.Update(request.Name, request.CPF, request.Idade, city);
            await _ApplicationDbContext.SaveChangesAsync();

            return new UpdatePeopleResponse();
        }
        public async Task<DeletePeopleResponse> DeleteByIdAsync(int idPeople)
        {
            var entity = await CheckAndReturnPeople(idPeople);

            _ApplicationDbContext.Remove(entity);
            await _ApplicationDbContext.SaveChangesAsync();

            return new DeletePeopleResponse();
        }

        #region Helpers
        private async Task<City> CheckAndReturnCity(int idCity)
        {
            var city = await _ApplicationDbContext.City.FirstOrDefaultAsync(c => c.Id == idCity);

            if (city == null) throw new Exception(NOT_FOUND_CITY);

            return city;
        }
        private async Task<People> CheckAndReturnPeople(int idPeople)
        {
            var people = await _ApplicationDbContext.People.FirstOrDefaultAsync(c => c.Id == idPeople);

            if (people == null) throw new Exception(SEARCH_NULL_ERROR);

            return people;
        }
        private static void CheckNullObject(object objects)
        {
            if (objects == null) throw new ArgumentException(EMPTY_ERROR);
        }
        #endregion

    }
}