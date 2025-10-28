using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SeatPlanDto> GetSeatPlanAsync(Guid busScheduleId)
        {
            var seats = await _context.Seats
                .Where(s => s.BusScheduleId == busScheduleId)
                .ToListAsync();

            return new SeatPlanDto
            {
                BusScheduleId = busScheduleId,
                Seats = seats.Select(s => new SeatDto
                {
                    SeatId = s.Id,
                    SeatNumber = s.SeatNumber,
                    Row = s.Row,
                    State = s.State
                }).ToList()
            };
        }

        public async Task<BookSeatResultDto> BookSeatAsync(BookSeatInputDto input)
        {
            var provider = _context.Database.ProviderName;
            var useTransaction = !string.Equals(provider, "Microsoft.EntityFrameworkCore.InMemory", StringComparison.OrdinalIgnoreCase);

            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = null;
            if (useTransaction)
            {
                transaction = await _context.Database.BeginTransactionAsync();
            }

            try
            {
                var seats = await _context.Seats
                    .Where(s => input.SeatIds.Contains(s.Id))
                    .ToListAsync();

                if (seats.Any(s => s.State != SeatState.Available))
                {
                    return new BookSeatResultDto
                    {
                        Success = false,
                        Message = "One or more seats are already booked."
                    };
                }

                var passenger = new Passenger
                {
                    Id = Guid.NewGuid(),
                    Name = input.PassengerName,
                    MobileNumber = input.MobileNumber
                };
                await _context.Passengers.AddAsync(passenger);

                foreach (var seat in seats)
                {
                    seat.State = SeatState.Booked;
                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        SeatId = seat.Id,
                        PassengerId = passenger.Id,
                        BookingTime = DateTime.UtcNow
                    };
                    seat.Ticket = ticket;
                    await _context.Tickets.AddAsync(ticket);
                }

                await _context.SaveChangesAsync();

                if (transaction != null)
                {
                    await transaction.CommitAsync();
                }

                return new BookSeatResultDto
                {
                    Success = true,
                    Message = "Seats booked successfully."
                };
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync();
                }

                return new BookSeatResultDto
                {
                    Success = false,
                    Message = $"Booking failed: {ex.Message}"
                };
            }
            finally
            {
                if (transaction != null)
                {
                    await transaction.DisposeAsync();
                }
            }
        }
    }
}
