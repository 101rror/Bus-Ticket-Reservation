using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Contracts.DTOs
{
    public class SeatPlanDto
    {
        public Guid BusScheduleId { get; set; }
        public List<SeatDto> Seats { get; set; } = new List<SeatDto>();
    }

    public class SeatDto
    {
        public Guid SeatId { get; set; }
        public string SeatNumber { get; set; } = null!;
        public int Row { get; set; }
        public SeatState State { get; set; }
    }
}
