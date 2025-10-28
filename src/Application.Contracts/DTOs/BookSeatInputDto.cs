using System;
using System.Collections.Generic;

namespace Application.Contracts.DTOs
{
    public class BookSeatInputDto
    {
        public Guid BusScheduleId { get; set; }
        public string PassengerName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public List<Guid> SeatIds { get; set; } = new List<Guid>();
    }
}
