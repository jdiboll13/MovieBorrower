﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieBorrower.Models;

namespace MovieBorrower.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MovieBorrower.Models.BorrowRecords> BorrowRecords { get; set; }

        //public DbSet<MovieBorrower.Models.Credits> Credits { get; set; }

        //public DbSet<MovieBorrower.Models.Movies> Movies { get; set; }

        //public DbSet<MovieBorrower.Models.Cast> Cast { get; set; }

        //public DbSet<MovieBorrower.Models.Actor> Actor { get; set; }

        //public DbSet<MovieBorrower.Models.GenreMovies> GenreMovies { get; set; }

        //public DbSet<MovieBorrower.Models.Genre> Genre { get; set; }

        //public DbSet<MovieBorrower.Models.Movie> Movie { get; set; }
    }
}
