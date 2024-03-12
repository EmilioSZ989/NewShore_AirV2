using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Repositories
{
    public class FlightRepository
    {
        private readonly MySQLiteContext _context;

        public FlightRepository(MySQLiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlight(int id)
        {
            return _context.Flights.Find(id);
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void RemoveFlight(Flight flight)
        {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }
    }
}
