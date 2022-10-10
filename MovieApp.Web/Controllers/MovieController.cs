#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var movie = await _dbContext.Movie.Include(m => m.Director)
                                  .Include(m => m.GenreMovie)
                                  .ThenInclude(gm => gm.Genre)
                                  .FirstOrDefaultAsync(d => d.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        var movieRequest = new MovieRequest(movie);

        await GetDirector();
        await GetGenre();

        return View(movieRequest);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MovieRequest request)
    {
        if (!ModelState.IsValid)
        {
            await GetDirector();
            await GetGenre();

            return View();
        }

        var updatedMovie = await _dbContext.Movie.Include(m => m.Director)
                                          .Include(m => m.GenreMovie)
                                          .ThenInclude(gm => gm.Genre)
                                          .FirstOrDefaultAsync(d => d.Id == request.Id);

        updatedMovie.Title = request.Title;
        updatedMovie.Description = request.Description;
        updatedMovie.DirectorId = request.DirectorId;
        updatedMovie.GenreMovie = request.GenreId.Select(gm => new GenreMovie()
                                                        {
                                                            GenreId = gm
                                                        }).ToList();

        _dbContext.Update(updatedMovie);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _dbContext.Movie.FirstOrDefaultAsync(d => d.Id == id);
        _dbContext.Movie.Remove(movie);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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

    private async Task GetDirector()
    {
        var direcotrList = await _dbContext.Director.OrderBy(d => d.FirstName).ThenBy(d => d.LastName).ToListAsync();

        List<SelectListItem> selectItems = new List<SelectListItem>();
        var firstItem = new SelectListItem("Select", "", false);
        selectItems.Add(firstItem);

        foreach (var direcotr in direcotrList)
        {
            var item = new SelectListItem(direcotr.FullName, direcotr.Id.ToString());
            selectItems.Add(item);
        }

        ViewBag.DirectorList = selectItems;
    }

    private async Task GetGenre()
    {
        var genreList = await _dbContext.Genre.OrderBy(g => g.Name).ToListAsync();

        List<SelectListItem> selectItems = new List<SelectListItem>();
        var firstItem = new SelectListItem("Select", "", false);
        selectItems.Add(firstItem);

        foreach(var genre in genreList)
        {
            var item = new SelectListItem(genre.Name, genre.Id.ToString());
            selectItems.Add(item);
        }

        ViewBag.GenreList = selectItems;
    }
}
