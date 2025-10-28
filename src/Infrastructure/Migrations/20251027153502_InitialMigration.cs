using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BusNumber = table.Column<string>(type: "text", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromCity = table.Column<string>(type: "text", nullable: false),
                    ToCity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<string>(type: "text", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_BusSchedules_BusScheduleId",
                        column: x => x.BusScheduleId,
                        principalTable: "BusSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusNumber", "Name", "TotalSeats" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "BUS-001", "LONDON Express", 30 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "BUS-002", "ENA", 40 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "FromCity", "ToCity" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Dhaka", "Chittagong" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Dhaka", "Sylhet" }
                });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "BusId", "JourneyDate", "RouteId" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BusScheduleId", "Row", "SeatNumber", "State" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777770001"), new Guid("55555555-5555-5555-5555-555555555555"), 1, "S01", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770002"), new Guid("55555555-5555-5555-5555-555555555555"), 1, "S02", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770003"), new Guid("55555555-5555-5555-5555-555555555555"), 1, "S03", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770004"), new Guid("55555555-5555-5555-5555-555555555555"), 1, "S04", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770005"), new Guid("55555555-5555-5555-5555-555555555555"), 2, "S05", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770006"), new Guid("55555555-5555-5555-5555-555555555555"), 2, "S06", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770007"), new Guid("55555555-5555-5555-5555-555555555555"), 2, "S07", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770008"), new Guid("55555555-5555-5555-5555-555555555555"), 2, "S08", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770009"), new Guid("55555555-5555-5555-5555-555555555555"), 3, "S09", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770010"), new Guid("55555555-5555-5555-5555-555555555555"), 3, "S10", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770011"), new Guid("55555555-5555-5555-5555-555555555555"), 3, "S11", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770012"), new Guid("55555555-5555-5555-5555-555555555555"), 3, "S12", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770013"), new Guid("55555555-5555-5555-5555-555555555555"), 4, "S13", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770014"), new Guid("55555555-5555-5555-5555-555555555555"), 4, "S14", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770015"), new Guid("55555555-5555-5555-5555-555555555555"), 4, "S15", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770016"), new Guid("55555555-5555-5555-5555-555555555555"), 4, "S16", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770017"), new Guid("55555555-5555-5555-5555-555555555555"), 5, "S17", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770018"), new Guid("55555555-5555-5555-5555-555555555555"), 5, "S18", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770019"), new Guid("55555555-5555-5555-5555-555555555555"), 5, "S19", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770020"), new Guid("55555555-5555-5555-5555-555555555555"), 5, "S20", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770021"), new Guid("55555555-5555-5555-5555-555555555555"), 6, "S21", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770022"), new Guid("55555555-5555-5555-5555-555555555555"), 6, "S22", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770023"), new Guid("55555555-5555-5555-5555-555555555555"), 6, "S23", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770024"), new Guid("55555555-5555-5555-5555-555555555555"), 6, "S24", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770025"), new Guid("55555555-5555-5555-5555-555555555555"), 7, "S25", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770026"), new Guid("55555555-5555-5555-5555-555555555555"), 7, "S26", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770027"), new Guid("55555555-5555-5555-5555-555555555555"), 7, "S27", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770028"), new Guid("55555555-5555-5555-5555-555555555555"), 7, "S28", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770029"), new Guid("55555555-5555-5555-5555-555555555555"), 8, "S29", 0 },
                    { new Guid("77777777-7777-7777-7777-777777770030"), new Guid("55555555-5555-5555-5555-555555555555"), 8, "S30", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880001"), new Guid("66666666-6666-6666-6666-666666666666"), 1, "S01", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880002"), new Guid("66666666-6666-6666-6666-666666666666"), 1, "S02", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880003"), new Guid("66666666-6666-6666-6666-666666666666"), 1, "S03", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880004"), new Guid("66666666-6666-6666-6666-666666666666"), 1, "S04", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880005"), new Guid("66666666-6666-6666-6666-666666666666"), 2, "S05", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880006"), new Guid("66666666-6666-6666-6666-666666666666"), 2, "S06", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880007"), new Guid("66666666-6666-6666-6666-666666666666"), 2, "S07", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880008"), new Guid("66666666-6666-6666-6666-666666666666"), 2, "S08", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880009"), new Guid("66666666-6666-6666-6666-666666666666"), 3, "S09", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880010"), new Guid("66666666-6666-6666-6666-666666666666"), 3, "S10", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880011"), new Guid("66666666-6666-6666-6666-666666666666"), 3, "S11", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880012"), new Guid("66666666-6666-6666-6666-666666666666"), 3, "S12", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880013"), new Guid("66666666-6666-6666-6666-666666666666"), 4, "S13", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880014"), new Guid("66666666-6666-6666-6666-666666666666"), 4, "S14", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880015"), new Guid("66666666-6666-6666-6666-666666666666"), 4, "S15", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880016"), new Guid("66666666-6666-6666-6666-666666666666"), 4, "S16", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880017"), new Guid("66666666-6666-6666-6666-666666666666"), 5, "S17", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880018"), new Guid("66666666-6666-6666-6666-666666666666"), 5, "S18", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880019"), new Guid("66666666-6666-6666-6666-666666666666"), 5, "S19", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880020"), new Guid("66666666-6666-6666-6666-666666666666"), 5, "S20", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880021"), new Guid("66666666-6666-6666-6666-666666666666"), 6, "S21", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880022"), new Guid("66666666-6666-6666-6666-666666666666"), 6, "S22", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880023"), new Guid("66666666-6666-6666-6666-666666666666"), 6, "S23", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880024"), new Guid("66666666-6666-6666-6666-666666666666"), 6, "S24", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880025"), new Guid("66666666-6666-6666-6666-666666666666"), 7, "S25", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880026"), new Guid("66666666-6666-6666-6666-666666666666"), 7, "S26", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880027"), new Guid("66666666-6666-6666-6666-666666666666"), 7, "S27", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880028"), new Guid("66666666-6666-6666-6666-666666666666"), 7, "S28", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880029"), new Guid("66666666-6666-6666-6666-666666666666"), 8, "S29", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880030"), new Guid("66666666-6666-6666-6666-666666666666"), 8, "S30", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880031"), new Guid("66666666-6666-6666-6666-666666666666"), 8, "S31", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880032"), new Guid("66666666-6666-6666-6666-666666666666"), 8, "S32", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880033"), new Guid("66666666-6666-6666-6666-666666666666"), 9, "S33", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880034"), new Guid("66666666-6666-6666-6666-666666666666"), 9, "S34", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880035"), new Guid("66666666-6666-6666-6666-666666666666"), 9, "S35", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880036"), new Guid("66666666-6666-6666-6666-666666666666"), 9, "S36", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880037"), new Guid("66666666-6666-6666-6666-666666666666"), 10, "S37", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880038"), new Guid("66666666-6666-6666-6666-666666666666"), 10, "S38", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880039"), new Guid("66666666-6666-6666-6666-666666666666"), 10, "S39", 0 },
                    { new Guid("88888888-8888-8888-8888-888888880040"), new Guid("66666666-6666-6666-6666-666666666666"), 10, "S40", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_BusId",
                table: "BusSchedules",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_RouteId",
                table: "BusSchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BusScheduleId",
                table: "Seats",
                column: "BusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
