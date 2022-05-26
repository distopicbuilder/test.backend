using Application.Models.Dtos;
using Application.Models.Request.City;
using Application.Models.Response.City;
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
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        #region Const
        private const string EMPTY_ERROR = "Objeto cidade não pode ser null.";
        private const string SEARCH_NULL_ERROR = "Nenhuma cidade encontrada.";
        private const string NOT_FOUND_CITY = "Cidade não encontrada.";
        #endregion

        #region Constructors
        public CityService(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }
        #endregion

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _ApplicationDbContext.City.AsNoTracking().ToListAsync();

            return new GetAllCityResponse()
            {
                Cities = entity != null ? entity.Select(a => (CityDto)a).ToList() : new List<CityDto>()
            };
        }
        public async Task<GetByIdCityResponse> GetByIdAsync(int idCity)
        {
            var entity = await CheckAndReturnCity(idCity);

            var response = new GetByIdCityResponse((CityDto)entity);

            return response;
        }
        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            CheckNullObject(request);

            var newCity = new City(request.Name, request.UF);

            _ApplicationDbContext.City.Add(newCity);

            await _ApplicationDbContext.SaveChangesAsync();

            return new CreateCityResponse() { Id = newCity.Id };
        }
        public async Task<UpdateCityResponse> UpdateAsync(UpdateCityRequest request)
        {
            CheckNullObject(request);

            var entity = await CheckAndReturnCity(request.Id);

            entity.Update(request.Name, request.UF);
            await _ApplicationDbContext.SaveChangesAsync();

            return new UpdateCityResponse();
        }
        public async Task<DeleteCityResponse> DeleteByIdAsync(int idCity)
        {
            var entity = await CheckAndReturnCity(idCity);

            _ApplicationDbContext.Remove(entity);
            await _ApplicationDbContext.SaveChangesAsync();

            return new DeleteCityResponse();
        }

        #region Helpers
        private async Task<City> CheckAndReturnCity(int idCity)
        {
            var city = await _ApplicationDbContext.City.FirstOrDefaultAsync(c => c.Id == idCity);

            if (city == null) throw new Exception(NOT_FOUND_CITY);

            return city;
        }
        private static void CheckNullObject(object objects)
        {
            if (objects == null) throw new ArgumentException(EMPTY_ERROR);
        }
        #endregion
    }
}
