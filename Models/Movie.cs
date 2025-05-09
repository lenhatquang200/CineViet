using System.ComponentModel.DataAnnotations;

namespace CineViet.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public string? Cast { get; set; }
        public string? Director { get; set; }
        public string Status { get; set; } // now, coming
    }
}