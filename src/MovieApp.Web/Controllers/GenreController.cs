using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL;
using MovieApp.Model;

namespace TFT.MovieLibrary.Web.Controllers;

public class GenreController : Controller
{
    private MovieAppDbContext _dbContext;

    public GenreController(MovieAppDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var genreList = await _dbContext.Genre.ToListAsync();

        return View(genreList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Genre newGenre)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _dbContext.Genre.AddAsync(newGenre);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var genre = await _dbContext.Genre.FirstOrDefaultAsync(d => d.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        return View(genre);
    }

    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> Edit(Genre updatedGenre)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _dbContext.Update(updatedGenre);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _dbContext.Genre.FirstOrDefaultAsync(d => d.Id == id);
        _dbContext.Genre.Remove(genre);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
