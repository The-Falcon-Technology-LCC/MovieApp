#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL;
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
        var movieResultList = new List<MovieResult>();
        return View(movieResultList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
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
