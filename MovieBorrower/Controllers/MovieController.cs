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
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var url = "https://api.themoviedb.org/3/list/34905?language=en-US&api_key=7223486cbe3b2345dadd575b76df36c9";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }
            var moviesList = JsonConvert.DeserializeObject<MoviesList>(rawResponse);
            return View(moviesList.Movies);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var movie_id = id;
            
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
            return View(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
