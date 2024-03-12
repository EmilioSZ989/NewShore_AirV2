using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly MySQLiteContext _context;

        public TransportController(MySQLiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transport>> GetTransports()
        {
            return _context.Transports.ToList();
        }

        [HttpGet("{flightNumber}")]
        public ActionResult<Transport> GetTransport(string flightNumber)
        {
            var transport = _context.Transports.Find(flightNumber);

            if (transport == null)
            {
                return NotFound();
            }

            return transport;
        }
    }
}
