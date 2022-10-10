#nullable disable
using Microsoft.AspNetCore.Mvc;
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
}
