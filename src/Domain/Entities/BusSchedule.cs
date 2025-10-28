using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BusSchedule
    {
        public Guid Id { get; set; }
        public Guid BusId { get; set; }
        public Bus Bus { get; set; } = null!;
        public Guid RouteId { get; set; }
        public Route Route { get; set; } = null!;
        public DateTime JourneyDate { get; set; }
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
