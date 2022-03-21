using Microsoft.AspNetCore.Mvc;
using Movies.Client.ApiServices;
using Movies.Client.Models;

namespace Movies.Client.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieApiService _movieApiService;

    public MoviesController(IMovieApiService movieApiService)
    {
        _movieApiService = movieApiService;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
        return View(await _movieApiService.GetMovies());
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        //if (id == null)
        //{
        //    return NotFound();
        //}

        //var movie = await _movieApiService.Movie
        //    .FirstOrDefaultAsync(m => m.Id == id);
        //if (movie == null)
        //{
        //    return NotFound();
        //}

        return View();
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,Owner,ImageUrl,Rating")] Movie movie)
    {
        //if (ModelState.IsValid)
        //{
        //    _movieApiService.Add(movie);
        //    await _movieApiService.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _movieApiService.Movie.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        return View();
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseDate,Owner,ImageUrl,Rating")] Movie movie)
    {
        //if (id != movie.Id)
        //{
        //    return NotFound();
        //}

        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _movieApiService.Update(movie);
        //        await _movieApiService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieExists(movie.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        //if (id == null)
        //{
        //    return NotFound();
        //}

        //var movie = await _movieApiService.Movie
        //    .FirstOrDefaultAsync(m => m.Id == id);
        //if (movie == null)
        //{
        //    return NotFound();
        //}

        return View();
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        //var movie = await _movieApiService.Movie.FindAsync(id);
        //_movieApiService.Movie.Remove(movie);
        //await _movieApiService.SaveChangesAsync();
        //return RedirectToAction(nameof(Index));
        return Ok();
    }

    private async Task<bool> MovieExists(int id)
    {
        var result = await _movieApiService.GetMovie(id);
        return result is not null;
    }
}