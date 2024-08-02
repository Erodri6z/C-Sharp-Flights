﻿using Flights.Api.Dtos;

namespace Flights.Api.EndPoints;

public static class FlightsEndPoints
{
  const string GetFlightEndPointName = "GetFlight";

  private static readonly List<FlightDto> flights = [
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
  
  public static WebApplication MapFlightsEndPoints (this WebApplication app)
  {
    
    // GET flights
    app.MapGet("flights", () => flights);

    // GET flights by id
    app.MapGet("flights/{id}", (int id) => 
    {
      FlightDto? flight = flights.Find(flight => flight.Id == id);

      return flight is null ? Results.NotFound() : Results.Ok(flight) ; 
    })
    .WithName(GetFlightEndPointName);

    // POST flights
    app.MapPost("flights", (CreateFlightDto newFlight) => {
      FlightDto flight = new (
        flights.Count + 1,
        newFlight.Airline,
        newFlight.Airport,
        newFlight.FlightNumber,
        newFlight.Departs
      );

      flights.Add(flight);

      return Results.CreatedAtRoute(GetFlightEndPointName, new { id = flight.Id }, flight);
    });

    // PUT and Update flights
    app.MapPut("flights/{id}", ( int id, UpdateFlightDto updatedFlight) => 
    {
      var index = flights.FindIndex(flight => flight.Id == id);

      if (index == -1)
      {
        return Results.NotFound();
      }

      flights[index] = new FlightDto(
        id,
        updatedFlight.Airline,
        updatedFlight.Airport,
        updatedFlight.FlightNumber, 
        updatedFlight.Departs
      );
      return Results.NoContent();
    });

    // Delete flights
    app.MapDelete("flights/{id}", (int id) =>
    {
      flights.RemoveAll(flight => flight.Id == id);

      return Results.NoContent();
    });

    return app;

  }
}
