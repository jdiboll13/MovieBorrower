using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieBorrower.Data;
using MovieBorrower.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MovieBorrower.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(long id)
        {
            var movie_id = id;
            // check local database if movie exists
            // if yes, then return that
            if (MovieExists(id))
            {
                return View(_context.Movie);
            }
            // else 
            // get data from API
            var url = "https://api.themoviedb.org/3/movie/" + movie_id + "?api_key=7223486cbe3b2345dadd575b76df36c9&language=en-US";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var movie = JsonConvert.DeserializeObject<Movie>(rawResponse);
            
            if (movie == null)
            {
                return NotFound();
            }
            // store in local db
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return View(movie);
        }

        private bool MovieExists(long id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
