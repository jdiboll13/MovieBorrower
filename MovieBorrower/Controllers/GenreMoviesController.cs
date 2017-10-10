using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieBorrower.Data;
using MovieBorrower.Models;

namespace MovieBorrower.Controllers
{
    public class GenreMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenreMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenreMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenreMovies.ToListAsync());
        }

        // GET: GenreMovies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovies = await _context.GenreMovies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (genreMovies == null)
            {
                return NotFound();
            }

            return View(genreMovies);
        }

        // GET: GenreMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenreMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Overview,ReleaseDate,PosterPath,Title")] GenreMovies genreMovies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreMovies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genreMovies);
        }

        // GET: GenreMovies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovies = await _context.GenreMovies.SingleOrDefaultAsync(m => m.Id == id);
            if (genreMovies == null)
            {
                return NotFound();
            }
            return View(genreMovies);
        }

        // POST: GenreMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Overview,ReleaseDate,PosterPath,Title")] GenreMovies genreMovies)
        {
            if (id != genreMovies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreMovies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreMoviesExists(genreMovies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genreMovies);
        }

        // GET: GenreMovies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genreMovies = await _context.GenreMovies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (genreMovies == null)
            {
                return NotFound();
            }

            return View(genreMovies);
        }

        // POST: GenreMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var genreMovies = await _context.GenreMovies.SingleOrDefaultAsync(m => m.Id == id);
            _context.GenreMovies.Remove(genreMovies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreMoviesExists(long id)
        {
            return _context.GenreMovies.Any(e => e.Id == id);
        }
    }
}
