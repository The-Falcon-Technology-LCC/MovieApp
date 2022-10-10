#nullable disable

using MovieApp.Model;

namespace MovieApp.Web.Models
{
    public class MovieResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }

        public MovieResult (Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Director = movie.Director.FullName;
            Genres = string.Join(", ", movie.GenreMovie.Select(gm => gm.Genre.Name).ToList());
        }
    }
}
