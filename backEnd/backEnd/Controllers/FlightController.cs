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
    public class FlightController : ControllerBase
    {
        private readonly MySQLiteContext _context;

        public FlightController(MySQLiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flight>> GetFlights()
        {
            var flightsWithTransport = _context.Flights.Include(f => f.Transport).ToList();
            return flightsWithTransport;
        }

        [HttpGet("{id}")]
        public ActionResult<Flight> GetFlight(int id)
        {
            var flightWithTransport = _context.Flights.Include(f => f.Transport).FirstOrDefault(f => f.Id == id);

            if (flightWithTransport == null)
            {
                return NotFound();
            }

            return flightWithTransport;
        }

        [HttpPost]
        public ActionResult<Flight> PostFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        [HttpDelete("{id}")]
        public ActionResult<Flight> DeleteFlight(int id)
        {
            var flight = _context.Flights
                .Include(f => f.Transport) // Incluimos el Transport para que se cargue junto con el Flight
                .FirstOrDefault(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            // Eliminar el Transport asociado
            if (flight.Transport != null)
            {
                _context.Transports.Remove(flight.Transport);
            }

            // Eliminar el Flight
            _context.Flights.Remove(flight);
            _context.SaveChanges();

            return flight;
        }

    }
}
