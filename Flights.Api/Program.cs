using Flights.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapFlightsEndPoints();

app.Run();
