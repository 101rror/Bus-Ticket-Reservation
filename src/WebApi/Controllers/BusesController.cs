using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] AddBusInputDto input)
        {
            // Ensure route exists (create if missing)
            var route = _context.Routes.FirstOrDefault(r => r.FromCity == input.FromCity && r.ToCity == input.ToCity);
            if (route == null)
            {
                // Fully qualify Route to avoid ambiguity with Microsoft.AspNetCore.Routing.Route
                route = new Domain.Entities.Route { Id = Guid.NewGuid(), FromCity = input.FromCity, ToCity = input.ToCity };
                await _context.Routes.AddAsync(route);
            }

            // Create bus
            var bus = new Bus
            {
                Id = Guid.NewGuid(),
                Name = input.BusName,
                BusNumber = input.BusNumber,
                TotalSeats = input.TotalSeats
            };
            await _context.Buses.AddAsync(bus);

            // Create schedule
            var schedule = new BusSchedule
            {
                Id = Guid.NewGuid(),
                BusId = bus.Id,
                RouteId = route.Id,
                JourneyDate = DateTime.SpecifyKind(input.JourneyDate, DateTimeKind.Utc)
            };
            await _context.BusSchedules.AddAsync(schedule);

            // Create seats (simple numbering S01..Snn, rows of 4)
            var seatsPerRow = 4;
            for (var i = 1; i <= input.TotalSeats; i++)
            {
                var seat = new Seat
                {
                    Id = Guid.NewGuid(),
                    BusScheduleId = schedule.Id,
                    SeatNumber = $"S{i:00}",
                    Row = ((i - 1) / seatsPerRow) + 1,
                    State = SeatState.Available
                };
                await _context.Seats.AddAsync(seat);
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true, busId = bus.Id, busScheduleId = schedule.Id });
        }
    }
}
