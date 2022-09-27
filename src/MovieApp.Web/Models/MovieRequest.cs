using MovieApp.Model;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Models
{
    public class MovieRequest 
    {
        public int? Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? DirectorId { get; set; }
        [Required]
        public IEnumerable<int>? GenreId { get; set; }

        public MovieRequest(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            DirectorId = (int)movie.DirectorId;
            GenreId = movie.GenreMovie.Select(gm => gm.GenreId).ToList();
        }
    }
}
