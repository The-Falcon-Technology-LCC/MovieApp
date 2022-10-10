#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(Director))]
        public int? DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<GenreMovie> GenreMovie { get; set; }
    }
}
