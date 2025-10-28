using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class SearchService
    {
        private readonly AppDbContext _context;

        public SearchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AvailableBusDto>> SearchAvailableBusesAsync(string from, string to, DateTime journeyDate)
        {
            var journeyDateUtc = DateTime.SpecifyKind(journeyDate.Date, DateTimeKind.Utc);

            var schedules = await _context.BusSchedules
                .Include(bs => bs.Bus)
                .Include(bs => bs.Route)
                .Include(bs => bs.Seats)
                .Where(bs => bs.Route.FromCity == from && bs.Route.ToCity == to && bs.JourneyDate.Date == journeyDateUtc.Date)
                .ToListAsync();

            var result = schedules.Select(bs => new AvailableBusDto
            {
                BusScheduleId = bs.Id,
                BusName = bs.Bus.Name,
                BusNumber = bs.Bus.BusNumber,
                FromCity = bs.Route.FromCity,
                ToCity = bs.Route.ToCity,
                JourneyDate = bs.JourneyDate,
                AvailableSeats = bs.Seats.Count(s => s.State == SeatState.Available)
            }).ToList();

            return result;
        }
    }
}
