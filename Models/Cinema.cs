using System.ComponentModel.DataAnnotations;

namespace CineViet.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}