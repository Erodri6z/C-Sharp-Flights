namespace Flights.Api.Dtos;

public record class CreateFlightDto
(
  string Airline,
  string Airport,
  int FlightNumber,
  DateOnly Departs
);
