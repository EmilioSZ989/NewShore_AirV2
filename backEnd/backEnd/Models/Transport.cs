using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Transport
    {
        [Key]
        public string FlightNumber { get; set; }

        [Required]
        public string FlightCarrier { get; set; }
    }
}
