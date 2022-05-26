using Application.Models.Request.City;
using Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var action = await _cityService.GetAllAsync();
                return Ok(action);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var action = await _cityService.GetByIdAsync(id);
                return Ok(action);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityRequest createCityRequest)
        {
            try
            {
                var action = await _cityService.CreateAsync(createCityRequest);
                return Ok(action);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCityRequest updateCityRequest)
        {
            try
            {
                var action = await _cityService.UpdateAsync(updateCityRequest);
                return Ok(action);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var action = await _cityService.DeleteByIdAsync(id);
                return Ok(action);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}