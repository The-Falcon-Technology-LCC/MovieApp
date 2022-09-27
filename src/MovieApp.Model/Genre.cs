#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Model
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<GenreMovie> GenreMovie { get; set; }
    }
}
