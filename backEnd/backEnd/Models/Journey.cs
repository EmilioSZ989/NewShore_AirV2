using BackEnd.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Journey
    {
        [Key]
        public int Id { get; set; }

        public List<Flight> Flights { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        public double Price { get; set; }
    }
}
