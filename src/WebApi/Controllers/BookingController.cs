using System;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{busScheduleId}/seats")]
        public async Task<IActionResult> GetSeatPlan(Guid busScheduleId)
        {
            var result = await _bookingService.GetSeatPlanAsync(busScheduleId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> BookSeat([FromBody] BookSeatInputDto input)
        {
            var result = await _bookingService.BookSeatAsync(input);
            return Ok(result);
        }
    }
}
