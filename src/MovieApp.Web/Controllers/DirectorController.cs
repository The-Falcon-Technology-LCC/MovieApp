using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DAL;
using MovieApp.Model;

namespace TFT.MovieLibrary.Web.Controllers;

public class DirectorController : Controller
{
    private MovieAppDbContext _dbContext;

    public DirectorController(MovieAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var directorList = await _dbContext.Director.ToListAsync();

        return View(directorList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Director newDirector)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _dbContext.Director.AddAsync(newDirector);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var director = await _dbContext.Director.FirstOrDefaultAsync(d => d.Id == id);

        if (director == null)
        {
            return NotFound();
        }

        return View(director);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Director updatedDirector)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _dbContext.Update(updatedDirector);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var director = await _dbContext.Director.FirstOrDefaultAsync(d => d.Id == id);
        _dbContext.Director.Remove(director);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
