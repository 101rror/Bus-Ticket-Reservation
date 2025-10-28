# Bus Ticket Reservation
Simple bus ticket reservation system (ASP.NET Web API backend + Angular frontend).


## Contents
- `src/BusTicketReservationSystem.sln` — Visual Studio solution
- `src/WebApi/` — ASP.NET Web API (startup project)
- `src/Infrastructure/` — EF Core persistence and migrations
- `src/Domain/` — domain entities
- `src/Application/` — application services and business logic
- `src/Application.Contracts/` — DTOs and contracts
- `src/ClientApp/` — Angular frontend
- `src/Tests/` — unit tests


Quick start for developers who clone this repo.

Prerequisites
- .NET SDK 7.0 or later
- Node.js 16+ and npm

# Clone and build

```powershell
git clone https://github.com/101rror/Bus-Ticket-Reservation.git
cd BusTicketReservation/src
dotnet restore
dotnet build -c Debug
```

# Configure database

Edit `WebApi/appsettings.Development.json`

Apply migrations (optional)

```powershell
dotnet ef database update --project Infrastructure/Infrastructure.csproj --startup-project WebApi/WebApi.csproj
```

# Running the Backend

To run the backend (.NET) application:

1. Open a terminal and navigate to `src/WebApi` directory.
2. Run the following command:

	```powershell
	dotnet run
	```

This will start the backend server.

# Run the API

```powershell
dotnet run --project WebApi/WebApi.csproj
```

# Run the frontend

```powershell
cd ClientApp
npm install
npm run start
```

# Run tests

```powershell
cd ..
dotnet test Tests/Tests.csproj
```