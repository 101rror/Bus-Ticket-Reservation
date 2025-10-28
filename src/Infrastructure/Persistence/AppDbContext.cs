using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Bus> Buses { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<BusSchedule> BusSchedules { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bus>().HasMany(b => b.Schedules).WithOne(s => s.Bus).HasForeignKey(s => s.BusId);
            modelBuilder.Entity<Route>().HasMany(r => r.BusSchedules).WithOne(s => s.Route).HasForeignKey(s => s.RouteId);
            modelBuilder.Entity<BusSchedule>().HasMany(bs => bs.Seats).WithOne(s => s.BusSchedule).HasForeignKey(s => s.BusScheduleId);

            // Seed Data with fixed GUIDs
            var bus1 = new Bus { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "LONDON Express", BusNumber = "BUS-001", TotalSeats = 30 };
            var bus2 = new Bus { Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "ENA", BusNumber = "BUS-002", TotalSeats = 40 };

            var route1 = new Route { Id = new Guid("33333333-3333-3333-3333-333333333333"), FromCity = "Dhaka", ToCity = "Chittagong" };
            var route2 = new Route { Id = new Guid("44444444-4444-4444-4444-444444444444"), FromCity = "Dhaka", ToCity = "Sylhet" };

            // Fixed journey date for seeding
            var journeyDate = new DateTime(2025, 10, 28, 0, 0, 0, DateTimeKind.Utc);
            var schedule1 = new BusSchedule { Id = new Guid("55555555-5555-5555-5555-555555555555"), BusId = bus1.Id, RouteId = route1.Id, JourneyDate = journeyDate };
            var schedule2 = new BusSchedule { Id = new Guid("66666666-6666-6666-6666-666666666666"), BusId = bus2.Id, RouteId = route2.Id, JourneyDate = journeyDate };

            var seats1 = Enumerable.Range(1, bus1.TotalSeats).Select(i => new Seat
            {
                Id = new Guid($"77777777-7777-7777-7777-777777770{i:000}"),
                BusScheduleId = schedule1.Id,
                SeatNumber = $"S{i:00}",
                Row = (i - 1) / 4 + 1,
                State = SeatState.Available
            }).ToArray();

            var seats2 = Enumerable.Range(1, bus2.TotalSeats).Select(i => new Seat
            {
                Id = new Guid($"88888888-8888-8888-8888-888888880{i:000}"),
                BusScheduleId = schedule2.Id,
                SeatNumber = $"S{i:00}",
                Row = (i - 1) / 4 + 1,
                State = SeatState.Available
            }).ToArray();

            modelBuilder.Entity<Bus>().HasData(bus1, bus2);
            modelBuilder.Entity<Route>().HasData(route1, route2);
            modelBuilder.Entity<BusSchedule>().HasData(schedule1, schedule2);
            modelBuilder.Entity<Seat>().HasData(seats1);
            modelBuilder.Entity<Seat>().HasData(seats2);
        }
    }
}
