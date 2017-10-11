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
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            // check local database if movies exists
            // if yes, then return that
            var count = _context.Movies.Count();
            if (count == 377)
            {
                return View(_context.Movies);
            }
            
            // else 
            // get data from API
            var url = "https://api.themoviedb.org/3/list/34905?language=en-US&api_key=7223486cbe3b2345dadd575b76df36c9";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();

            var rawResponse = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }
            // store in local db
            var moviesList = JsonConvert.DeserializeObject<MoviesList>(rawResponse);
            //_context.Add(moviesList.Movies);
            //await _context.SaveChangesAsync();
            return View(moviesList.Movies);
        }
    }
}
