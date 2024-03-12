using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Repositories
{
    public class JourneyRepository
    {
        private readonly MySQLiteContext _context;

        public JourneyRepository(MySQLiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Journey> GetAllJourneys()
        {
            return _context.Journeys.ToList();
        }

        public Journey GetJourney(int id)
        {
            return _context.Journeys.Find(id);
        }

        public void AddJourney(Journey journey)
        {
            _context.Journeys.Add(journey);
            _context.SaveChanges();
        }

        public void RemoveJourney(Journey journey)
        {
            _context.Journeys.Remove(journey);
            _context.SaveChanges();
        }
    }
}
