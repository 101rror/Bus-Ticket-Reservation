using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Bus
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string BusNumber { get; set; } = null!;
        public int TotalSeats { get; set; }
        public ICollection<BusSchedule> Schedules { get; set; } = new List<BusSchedule>();
    }
}
