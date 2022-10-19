#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL;
using MovieApp.Model;
using MovieApp.Web.Models;

namespace TFT.MovieLibrary.Web.Controllers;

public class MovieController : Controller
{
    private MovieAppDbContext _dbContext;

    public MovieController(MovieAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var movieList = await _dbContext.Movie
                                        .Include(m => m.Director)
                                        .Include(m => m.GenreMovie)
                                        .ThenInclude(gm => gm.Genre)
                                        .ToListAsync();

        var movieResultList = movieList.Select(m => new MovieResult(m));
        return View(movieResultList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await GetDirector();
        await GetGenre();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MovieRequest request)
    {
        if (!ModelState.IsValid)
        {
            await GetDirector();
            await GetGenre();

            return View();
        }

        var newMovie = new Movie()
        {
            Title = request.Title,
            Description = request.Description,
            DirectorId = request.DirectorId,
            GenreMovie = request.GenreId.Select(gm => new GenreMovie()
            {
                GenreId = gm
            }).ToList()
        };

        await _dbContext.Movie.AddAsync(newMovie);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var movieRequest = new MovieRequest();
        return View(movieRequest);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _dbContext.Movie.Include(m => m.Director)
                                          .Include(m => m.GenreMovie)
                                          .ThenInclude(gm => gm.Genre)
                                          .FirstOrDefaultAsync(d => d.Id == id);

        return View(new MovieResult(movie));
    }
}
