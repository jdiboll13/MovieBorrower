﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieBorrower.Data;
using MovieBorrower.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace MovieBorrower.Controllers
{
    public class BorrowRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BorrowRecordsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BorrowRecords/Details/5
        [Authorize]
        public async Task<IActionResult> Details()
        {

            var user = await _userManager.GetUserAsync(User);

            var borrowRecords = _context.BorrowRecords.Where(w => w.ApplicationUserId == user.Id);
            if (borrowRecords == null)
            {
                return NotFound();
            }

            return View(borrowRecords);
        }

        // GET: BorrowRecords/Create
        [Authorize]
        public IActionResult Create(int? id)
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

        // POST: BorrowRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int id, [FromForm] string title, [FromForm] string posterPath)
        {
            var borrowRecords = new BorrowRecords
            {
                MovieId = id,
                Title = title,
                PosterPath = posterPath
            };

            var user = await _userManager.GetUserAsync(User);
            borrowRecords.ApplicationUserId = user.Id;
            _context.Add(borrowRecords);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));

        }

        // GET: BorrowRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecords = await _context.BorrowRecords.SingleOrDefaultAsync(m => m.Id == id);
            if (borrowRecords == null)
            {
                return NotFound();
            }
            return View(borrowRecords);
        }

        // POST: BorrowRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,PickUpDate,DueDate,ApplicationUser")] BorrowRecords borrowRecords)
        {
            if (id != borrowRecords.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowRecordsExists(borrowRecords.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(borrowRecords);
        }

        // GET: BorrowRecords/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowRecords = await _context.BorrowRecords
                .SingleOrDefaultAsync(m => m.Id == id);
            if (borrowRecords == null)
            {
                return NotFound();
            }

            return View(borrowRecords);
        }

        // POST: BorrowRecords/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowRecords = await _context.BorrowRecords.SingleOrDefaultAsync(m => m.Id == id);
            _context.BorrowRecords.Remove(borrowRecords);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }

        private bool BorrowRecordsExists(int id)
        {
            return _context.BorrowRecords.Any(e => e.Id == id);
        }
    }
}
