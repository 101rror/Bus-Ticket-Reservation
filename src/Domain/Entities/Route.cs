using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Route
    {
        public Guid Id { get; set; }
        public string FromCity { get; set; } = null!;
        public string ToCity { get; set; } = null!;
        public ICollection<BusSchedule> BusSchedules { get; set; } = new List<BusSchedule>();
    }
}
