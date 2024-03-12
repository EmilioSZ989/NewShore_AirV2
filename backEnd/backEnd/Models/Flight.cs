using BackEnd.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Transport Transport { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        public double Price { get; set; }
        
        [ForeignKey("JourneyId")]
        public int? JourneyId { get; set; } 

        
    }
}
