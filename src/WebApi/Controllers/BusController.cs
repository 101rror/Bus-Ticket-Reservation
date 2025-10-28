using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] AddBusDto input)
        {
            var busId = await _busService.AddBusAsync(input);
            return Ok(busId);
        }
    }
}