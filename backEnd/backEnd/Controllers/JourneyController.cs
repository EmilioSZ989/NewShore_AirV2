using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly MySQLiteContext _context;

        public JourneyController(MySQLiteContext context)
        {
            _context = context;
        }

        [HttpGet("route")]
        public ActionResult<Journey> GetFlightRoute([FromQuery] string origin, [FromQuery] string destination)
        {
            var flightRoute = FindFlightRoute(origin, destination);
            if (flightRoute.Count == 0)
            {
                return NotFound("No se encontró una ruta de vuelo válida para el origen y destino proporcionados.");
            }

            // Cargar el objeto Transport para cada Flight
            foreach (var flight in flightRoute)
            {
                _context.Entry(flight)
                    .Reference(f => f.Transport)
                    .Load();
            }

            // Restablecer JourneyId a null para cada Flight
            foreach (var flight in flightRoute)
            {
                flight.JourneyId = null;
            }

            var journey = new Journey
            {
                Origin = origin,
                Destination = destination,
                Flights = flightRoute,
                Price = CalculateTotalPrice(flightRoute)
            };

            // Guardar el Journey en la base de datos
            _context.Journeys.Add(journey);
            _context.SaveChanges();

            return journey;
        }


        // Método para encontrar la ruta de vuelo (directa o indirecta)
        private List<Flight> FindFlightRoute(string origin, string destination)
        {
            var route = new List<Flight>();
            FindFlightRouteHelper(origin, destination, new List<string>(), route);
            return route;
        }

        // Método auxiliar recursivo para encontrar la ruta de vuelo
        private void FindFlightRouteHelper(string currentOrigin, string destination, List<string> visited, List<Flight> route)
        {
            if (currentOrigin.Equals(destination))
            {
                return; // Llegamos al destino
            }

            visited.Add(currentOrigin); // Marcamos el origen como visitado

            var flights = _context.Flights.Where(f => f.Origin == currentOrigin).ToList();
            foreach (var flight in flights)
            {
                if (!visited.Contains(flight.Destination))
                {
                    route.Add(flight); // Agregamos el vuelo a la ruta
                    FindFlightRouteHelper(flight.Destination, destination, visited, route);
                    if (route.Last().Destination == destination)
                    {
                        return; // Se encontró una ruta
                    }
                    route.Remove(flight); // Retrocedemos y eliminamos el vuelo de la ruta
                }
            }
        }

        // Método para calcular el precio total de la ruta
        private double CalculateTotalPrice(List<Flight> flights)
        {
            return flights.Sum(f => f.Price);
        }
    }
}
