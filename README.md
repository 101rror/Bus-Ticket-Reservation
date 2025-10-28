# Bus Ticket Reservation

Simple bus ticket reservation system (ASP.NET Web API backend + Angular frontend).

Quick start for developers who clone this repo.

Prerequisites
- .NET SDK 7.0 or later
- Node.js 16+ and npm

Clone and build

```powershell
git clone https://github.com/101rror/Bus-Ticket-Reservation.git
cd BusTicketReservation/src
dotnet restore
dotnet build -c Debug
```

Configure database

Edit `WebApi/appsettings.Development.json` (or set environment variable `ConnectionStrings__DefaultConnection`) with your DB connection string. Example for LocalDB on Windows:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BusTicketReservationDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Apply migrations (optional)

```powershell
dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project WebApi/WebApi.csproj
```

Run the API

```powershell
dotnet run --project WebApi/WebApi.csproj
```

Run the frontend

```powershell
cd ClientApp
npm install
npm run start
```

Run tests

```powershell
cd ..
dotnet test Tests/Tests.csproj
```

Project layout (short)
- `WebApi/` — ASP.NET API
- `Infrastructure/` — EF Core and persistence
- `Domain/` — domain entities
- `Application/` — services
- `Application.Contracts/` — DTOs
- `ClientApp/` — Angular frontend
- `Tests/` — unit tests

Notes
- If builds fail, ensure your .NET SDK matches project target frameworks in `src/*/*.csproj`.
- For DB issues, verify the connection string and DB server availability.

Enjoy — this README is intentionally minimal for quick cloning and local development.
## Contents
- `src/BusTicketReservationSystem.sln` — Visual Studio solution
- `src/WebApi/` — ASP.NET Web API (startup project)
- `src/Infrastructure/` — EF Core persistence and migrations
- `src/Domain/` — domain entities
- `src/Application/` — application services and business logic
- `src/Application.Contracts/` — DTOs and contracts
- `src/ClientApp/` — Angular frontend
- `src/Tests/` — unit tests


## Quick start
Open a terminal in the repository root (the directory that contains `src/`). The solution file is in `src/BusTicketReservationSystem.sln` so most commands assume you run them from `src/`.

1. Restore and build

```powershell
cd src
dotnet restore
dotnet build BusTicketReservationSystem.sln -c Debug
```

2. Configure the database

Edit `WebApi/appsettings.Development.json` (or `appsettings.json`) and update the `ConnectionStrings` key used by the application.

4. Run the Web API

```powershell
# from src/
dotnet run --project WebApi/WebApi.csproj
```

5. Run the Angular client

Open a separate terminal and run:

```powershell
cd src/ClientApp
npm install
npm run start
```

6. Run tests

```powershell
cd src
dotnet test Tests/Tests.csproj
```