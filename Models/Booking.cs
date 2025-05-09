using System;
using System.ComponentModel.DataAnnotations;

namespace CineViet.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int ShowtimeId { get; set; }
        [Required]
        public string Seats { get; set; } // VD: "A1,A2,B3"
        public int TotalPrice { get; set; }
        public DateTime BookingTime { get; set; }
        public Showtime Showtime { get; set; }
        public string Status { get; set; } // pending, paid, printed
    }
}