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


app.MapGet("flights", () => flights);

app.MapGet("/", () => "Hello World!");

app.Run();
