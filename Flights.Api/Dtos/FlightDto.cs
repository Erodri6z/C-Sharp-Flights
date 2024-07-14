namespace Flights.Api.Dtos;

public record class FlightDto
(
  int Id,
  string Airline,
  string Airport,
  int FlightNumber,
  DateOnly Departs
);
