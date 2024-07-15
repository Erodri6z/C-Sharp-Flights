namespace Flights.Api.Dtos;

public record class UpdateFlightDto
(
  string Airline,
  string Airport,
  int FlightNumber,
  DateOnly Departs
);
