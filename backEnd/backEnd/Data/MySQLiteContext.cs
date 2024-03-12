using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Security.Cryptography.Xml;

namespace BackEnd.Data
{
    public class MySQLiteContext : DbContext
    {
        public MySQLiteContext(DbContextOptions<MySQLiteContext> options) : base(options)
        {
        }

        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones si es necesario
            modelBuilder.Entity<Journey>()
                .HasMany(j => j.Flights)
                .WithOne()
                .HasForeignKey(f => f.JourneyId);
        }
    }
}
