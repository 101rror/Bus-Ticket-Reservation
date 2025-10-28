using System;

namespace Application.Contracts.DTOs
{
    public class AddBusInputDto
    {
        public string BusName { get; set; } = null!;
        public string BusNumber { get; set; } = null!;
        public string FromCity { get; set; } = null!;
        public string ToCity { get; set; } = null!;
        public DateTime JourneyDate { get; set; }
        public int TotalSeats { get; set; }
    }
}
