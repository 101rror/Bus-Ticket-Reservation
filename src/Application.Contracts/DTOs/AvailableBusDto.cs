using System;

namespace Application.Contracts.DTOs
{
    public class AvailableBusDto
    {
        public Guid BusScheduleId { get; set; }
        public string BusName { get; set; } = null!;
        public string BusNumber { get; set; } = null!;
        public string FromCity { get; set; } = null!;
        public string ToCity { get; set; } = null!;
        public DateTime JourneyDate { get; set; }
        public int AvailableSeats { get; set; }
    }
}
