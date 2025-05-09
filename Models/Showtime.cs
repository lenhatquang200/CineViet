using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineViet.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CinemaId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
    }
}