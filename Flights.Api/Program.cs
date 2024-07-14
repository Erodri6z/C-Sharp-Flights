using Flights.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<FlightDto> flights = [
  new ( 
    1,
    "American",
    "DEN",
    2333,
    new DateOnly(2022, 7, 2)
  ),
  new (
    2,
    "Southwest",
    "SAN",
    2753,
    new DateOnly(2023, 2, 4)
  ),
  new (
    3,
    "United",
    "DEN",
    2333,
    new DateOnly(2023, 1, 4)
  ),
  new (
    4,
    "United",
    "DFW",
    4233,
    new DateOnly(2023, 3, 8)
  )
];

// GET flights
app.MapGet("flights", () => flights);

// GET flights by id
app.MapGet("flights/{id}", (int id) => flights.Find(flight => flight.Id == id))
.WithName("GetFlight");

app.MapPost("flights", (CreateFlightDto newFlight) => {
  FlightDto flight = new (
    flights.Count + 1,
    newFlight.Airline,
    newFlight.Airport,
    newFlight.FlightNumber,
    newFlight.Departs);
  flights.Add(flight);

  return Results.CreatedAtRoute("GetFlight", new { id = flight.Id }, flight);
});



app.Run();
