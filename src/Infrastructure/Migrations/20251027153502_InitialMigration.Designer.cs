using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20251027153502_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Bus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BusNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            BusNumber = "BUS-001",
                            Name = "Volvo AC",
                            TotalSeats = 30
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            BusNumber = "BUS-002",
                            Name = "Mercedes Deluxe",
                            TotalSeats = 40
                        });
                });

            modelBuilder.Entity("Domain.Entities.BusSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("JourneyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("RouteId");

                    b.ToTable("BusSchedules");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            BusId = new Guid("11111111-1111-1111-1111-111111111111"),
                            JourneyDate = new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                            RouteId = new Guid("33333333-3333-3333-3333-333333333333")
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            BusId = new Guid("22222222-2222-2222-2222-222222222222"),
                            JourneyDate = new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc),
                            RouteId = new Guid("44444444-4444-4444-4444-444444444444")
                        });
                });

            modelBuilder.Entity("Domain.Entities.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FromCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ToCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            FromCity = "Dhaka",
                            ToCity = "Chittagong"
                        },
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            FromCity = "Dhaka",
                            ToCity = "Sylhet"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusScheduleId")
                        .HasColumnType("uuid");

                    b.Property<int>("Row")
                        .HasColumnType("integer");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BusScheduleId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770001"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 1,
                            SeatNumber = "S01",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770002"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 1,
                            SeatNumber = "S02",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770003"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 1,
                            SeatNumber = "S03",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770004"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 1,
                            SeatNumber = "S04",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770005"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 2,
                            SeatNumber = "S05",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770006"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 2,
                            SeatNumber = "S06",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770007"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 2,
                            SeatNumber = "S07",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770008"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 2,
                            SeatNumber = "S08",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770009"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 3,
                            SeatNumber = "S09",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770010"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 3,
                            SeatNumber = "S10",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770011"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 3,
                            SeatNumber = "S11",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770012"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 3,
                            SeatNumber = "S12",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770013"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 4,
                            SeatNumber = "S13",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770014"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 4,
                            SeatNumber = "S14",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770015"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 4,
                            SeatNumber = "S15",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770016"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 4,
                            SeatNumber = "S16",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770017"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 5,
                            SeatNumber = "S17",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770018"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 5,
                            SeatNumber = "S18",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770019"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 5,
                            SeatNumber = "S19",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770020"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 5,
                            SeatNumber = "S20",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770021"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 6,
                            SeatNumber = "S21",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770022"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 6,
                            SeatNumber = "S22",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770023"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 6,
                            SeatNumber = "S23",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770024"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 6,
                            SeatNumber = "S24",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770025"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 7,
                            SeatNumber = "S25",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770026"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 7,
                            SeatNumber = "S26",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770027"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 7,
                            SeatNumber = "S27",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770028"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 7,
                            SeatNumber = "S28",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770029"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 8,
                            SeatNumber = "S29",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777770030"),
                            BusScheduleId = new Guid("55555555-5555-5555-5555-555555555555"),
                            Row = 8,
                            SeatNumber = "S30",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880001"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 1,
                            SeatNumber = "S01",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880002"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 1,
                            SeatNumber = "S02",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880003"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 1,
                            SeatNumber = "S03",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880004"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 1,
                            SeatNumber = "S04",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880005"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 2,
                            SeatNumber = "S05",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880006"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 2,
                            SeatNumber = "S06",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880007"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 2,
                            SeatNumber = "S07",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880008"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 2,
                            SeatNumber = "S08",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880009"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 3,
                            SeatNumber = "S09",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880010"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 3,
                            SeatNumber = "S10",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880011"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 3,
                            SeatNumber = "S11",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880012"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 3,
                            SeatNumber = "S12",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880013"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 4,
                            SeatNumber = "S13",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880014"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 4,
                            SeatNumber = "S14",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880015"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 4,
                            SeatNumber = "S15",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880016"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 4,
                            SeatNumber = "S16",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880017"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 5,
                            SeatNumber = "S17",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880018"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 5,
                            SeatNumber = "S18",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880019"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 5,
                            SeatNumber = "S19",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880020"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 5,
                            SeatNumber = "S20",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880021"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 6,
                            SeatNumber = "S21",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880022"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 6,
                            SeatNumber = "S22",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880023"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 6,
                            SeatNumber = "S23",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880024"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 6,
                            SeatNumber = "S24",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880025"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 7,
                            SeatNumber = "S25",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880026"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 7,
                            SeatNumber = "S26",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880027"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 7,
                            SeatNumber = "S27",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880028"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 7,
                            SeatNumber = "S28",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880029"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 8,
                            SeatNumber = "S29",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880030"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 8,
                            SeatNumber = "S30",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880031"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 8,
                            SeatNumber = "S31",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880032"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 8,
                            SeatNumber = "S32",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880033"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 9,
                            SeatNumber = "S33",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880034"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 9,
                            SeatNumber = "S34",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880035"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 9,
                            SeatNumber = "S35",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880036"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 9,
                            SeatNumber = "S36",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880037"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 10,
                            SeatNumber = "S37",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880038"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 10,
                            SeatNumber = "S38",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880039"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 10,
                            SeatNumber = "S39",
                            State = 0
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888880040"),
                            BusScheduleId = new Guid("66666666-6666-6666-6666-666666666666"),
                            Row = 10,
                            SeatNumber = "S40",
                            State = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("SeatId")
                        .IsUnique();

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.BusSchedule", b =>
                {
                    b.HasOne("Domain.Entities.Bus", "Bus")
                        .WithMany("Schedules")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Route", "Route")
                        .WithMany("BusSchedules")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Domain.Entities.Seat", b =>
                {
                    b.HasOne("Domain.Entities.BusSchedule", "BusSchedule")
                        .WithMany("Seats")
                        .HasForeignKey("BusScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusSchedule");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Seat", "Seat")
                        .WithOne("Ticket")
                        .HasForeignKey("Domain.Entities.Ticket", "SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Domain.Entities.Bus", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Domain.Entities.BusSchedule", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Domain.Entities.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Route", b =>
                {
                    b.Navigation("BusSchedules");
                });

            modelBuilder.Entity("Domain.Entities.Seat", b =>
                {
                    b.Navigation("Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}
