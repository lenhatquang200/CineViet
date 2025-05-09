using System.ComponentModel.DataAnnotations;

namespace CineViet.Models
{
    public class Seat
    {
        public int Id { get; set; }
        [Required]
        public string Row { get; set; }
        [Required]
        public int Number { get; set; }
        public bool IsVip { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
    }
}