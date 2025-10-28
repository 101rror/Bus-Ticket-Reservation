using System;

namespace Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; } = null!;
        public DateTime BookingTime { get; set; } = DateTime.UtcNow;
    }
}
