using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Repositories
{
    public class TransportRepository
    {
        private readonly MySQLiteContext _context;

        public TransportRepository(MySQLiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Transport> GetAllTransports()
        {
            return _context.Transports.ToList();
        }

        public Transport GetTransport(string flightNumber)
        {
            return _context.Transports.Find(flightNumber);
        }

        public void AddTransport(Transport transport)
        {
            _context.Transports.Add(transport);
            _context.SaveChanges();
        }

        public void RemoveTransport(Transport transport)
        {
            _context.Transports.Remove(transport);
            _context.SaveChanges();
        }
    }
}
