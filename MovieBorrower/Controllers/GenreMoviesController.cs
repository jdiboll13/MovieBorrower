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
    public class GenreMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenreMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenreMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var genre_id = id;

            if (id == null)
            {
                return NotFound();
            }

            var url = "https://api.themoviedb.org/3/genre/" + genre_id + "/movies?api_key=7223486cbe3b2345dadd575b76df36c9&language=en-US&include_adult=false&sort_by=created_at.asc";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var genreMovies = JsonConvert.DeserializeObject<GenreMovies>(rawResponse);
            
            if (genreMovies == null)
            {
                return NotFound();
            }

            return View(genreMovies);
        }
        
        private bool GenreMoviesExists(int id)
        {
            return _context.GenreMovies.Any(e => e.Id == id);
        }
    }
}
