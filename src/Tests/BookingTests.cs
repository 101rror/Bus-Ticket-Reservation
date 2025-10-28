using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.DTOs;
using Application.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class BookingTests
{
    private async Task<AppDbContext> GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    [Fact]
    public async Task CanBookAvailableSeat()
    {
        var context = await GetDbContext();
        var bookingService = new BookingService(context);
        var seat = context.Seats.First(s => s.State == Domain.Entities.SeatState.Available);

        var result = await bookingService.BookSeatAsync(new BookSeatInputDto
        {
            BusScheduleId = seat.BusScheduleId,
            PassengerName = "Test User",
            MobileNumber = "1234567890",
            SeatIds = new System.Collections.Generic.List<Guid> { seat.Id }
        });

        Assert.True(result.Success);
        var updatedSeat = context.Seats.Find(seat.Id);
        Assert.Equal(Domain.Entities.SeatState.Booked, updatedSeat!.State);
    }

    [Fact]
    public async Task CannotBookAlreadyBookedSeat()
    {
        var context = await GetDbContext();
        var bookingService = new BookingService(context);
        var seat = context.Seats.First(s => s.State == Domain.Entities.SeatState.Available);

        await bookingService.BookSeatAsync(new BookSeatInputDto
        {
            BusScheduleId = seat.BusScheduleId,
            PassengerName = "User1",
            MobileNumber = "111",
            SeatIds = new System.Collections.Generic.List<Guid> { seat.Id }
        });

        var result2 = await bookingService.BookSeatAsync(new BookSeatInputDto
        {
            BusScheduleId = seat.BusScheduleId,
            PassengerName = "User2",
            MobileNumber = "222",
            SeatIds = new System.Collections.Generic.List<Guid> { seat.Id }
        });

        Assert.False(result2.Success);
    }
}
