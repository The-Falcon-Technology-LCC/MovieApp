#nullable disable
using Microsoft.EntityFrameworkCore;
using MovieApp.Model;

namespace MovieApp.DAL
{

    public class MovieAppDbContext : DbContext
    {
        protected MovieAppDbContext()
        {
        }

        public MovieAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Director> Director { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<GenreMovie> GenreMovie { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GenreMovie>().HasKey(gm => new { gm.GenreId, gm.MovieId });

            modelBuilder.Entity<GenreMovie>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.GenreMovie)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<GenreMovie>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.GenreMovie)
                .HasForeignKey(mg => mg.GenreId);

            //Director
            modelBuilder.Entity<Director>().HasData(new Director
            {
                Id = 1,
                FirstName = "Denis",
                LastName = "Villeneuve",
                DOB = DateTime.Parse("October 3 1967")
            });

            modelBuilder.Entity<Director>().HasData(new Director
            {
                Id = 2,
                FirstName = "Christopher",
                LastName = "Nolan",
                DOB = DateTime.Parse("July 30 1970")
            });

            modelBuilder.Entity<Director>().HasData(new Director
            {
                Id = 3,
                FirstName = "Quentin",
                LastName = "Tarantino",
                DOB = DateTime.Parse("March 27 1963")
            });


            //Genre
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 1,
                Name = "Thriller"
            });

            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 2,
                Name = "Drama"
            });

            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 3,
                Name = "Action"
            });

            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 4,
                Name = "Comedy"
            });

            //Movie
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "Blade Runner 2049",
                Description = "K, an officer with the Los Angeles Police Department, unearths a secret that could create chaos. He goes in search of a former blade runner who has been missing for over three decades.",
                DirectorId = 1
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "Sicario",
                Description = "During a dangerous mission to stop a drug cartel operating between the US and Mexico, Kate Macer, an FBI agent, is exposed to some harsh realities.",
                DirectorId = 1
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "Inception",
                Description = "Cobb steals information from his targets by entering their dreams. Saito offers to wipe clean Cobb's criminal history as payment for performing an inception on his sick competitor's son.",
                DirectorId = 2
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 4,
                Title = "Interstellar",
                Description = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                DirectorId = 2
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 5,
                Title = "Pulp Fiction",
                Description = "In the realm of underworld, a series of incidents intertwines the lives of two Los Angeles mobsters, a gangster's wife, a boxer and two small-time criminals.",
                DirectorId = 3
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 6,
                Title = "Reservoir Dogs",
                Description = "Six criminals, hired to steal diamonds, do not know each other's true identity. While attempting the heist, the police ambushes them, leading them to believe that one of them is an undercover officer.",
                DirectorId = 3
            });

            //GenreMovie
            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 1,
                MovieId = 1,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 2,
                MovieId = 1,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 3,
                MovieId = 1,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 1,
                MovieId = 2,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 3,
                MovieId = 2,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 1,
                MovieId = 3,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 3,
                MovieId = 3,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 1,
                MovieId = 4,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 3,
                MovieId = 5,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 4,
                MovieId = 5,
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie
            {
                GenreId = 3,
                MovieId = 6,
            });
        }
    }
}

//dotnet ef migrations add Initial --startup-project src/MovieApp.Web --context MovieAppDbContext --project src/MovieApp.DAL

//dotnet ef database update Initial --startup-project src/MovieApp.Web --context MovieAppDbContext --project src/MovieApp.DAL
