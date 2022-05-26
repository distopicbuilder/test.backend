using Application.Models.Request.People;
using Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        
        private readonly ILogger<PeopleController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var action = await _peopleService.GetAllAsync();
                return Ok(action);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, (error.Message));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var action = await _peopleService.GetByIdAsync(id);
                return Ok(action);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, (error.Message));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePeopleRequest createPeopleRequest)
        {
            try
            {
                var action = await _peopleService.CreateAsync(createPeopleRequest);
                return Ok(action);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, (error.Message));
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePeopleRequest updatePeopleRequest)
        {
            try
            {
                var action = await _peopleService.UpdateAsync(updatePeopleRequest);
                return Ok(action);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, (error.Message));
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var action = await _peopleService.DeleteByIdAsync(id);
                return Ok(action);
            }
            catch (Exception error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, (error.Message));
            }
        }
    }
}