using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
