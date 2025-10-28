using System;

namespace Domain.Entities
{
    public enum SeatState
    {
        Available,
        Booked,
        Sold
    }

    public class Seat
    {
        public Guid Id { get; set; }
        public Guid BusScheduleId { get; set; }
        public BusSchedule BusSchedule { get; set; } = null!;
        public string SeatNumber { get; set; } = null!;
        public int Row { get; set; }
        public SeatState State { get; set; } = SeatState.Available;
        public Ticket? Ticket { get; set; }
    }
}
