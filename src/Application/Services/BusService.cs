using System;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BusService : IBusService
    {
        private readonly AppDbContext _context;

        public BusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddBusAsync(AddBusDto input)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(r => 
                r.FromCity == input.FromCity && 
                r.ToCity == input.ToCity);

            if (route == null)
            {
                route = new Route
                {
                    FromCity = input.FromCity,
                    ToCity = input.ToCity
                };
                _context.Routes.Add(route);
                await _context.SaveChangesAsync();
            }

            var bus = new Bus
            {
                Name = input.BusName,
                BusNumber = input.BusNumber,
                TotalSeats = input.TotalSeats
            };
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();

            var schedule = new BusSchedule
            {
                BusId = bus.Id,
                RouteId = route.Id,
                JourneyDate = input.JourneyDate
            };
            _context.BusSchedules.Add(schedule);
            await _context.SaveChangesAsync();

            // Create seats for the bus
            for (int i = 1; i <= input.TotalSeats; i++)
            {
                var seat = new Seat
                {
                    BusScheduleId = schedule.Id,
                    SeatNumber = i.ToString(),
                    Row = (i - 1) / 4 + 1,
                    State = SeatState.Available
                };
                _context.Seats.Add(seat);
            }
            await _context.SaveChangesAsync();

            return bus.Id;
        }
    }
}