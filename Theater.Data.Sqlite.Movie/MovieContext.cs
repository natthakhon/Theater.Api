using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Theater.Data.Sqlite.Movie.Db;

namespace Theater.Data.Sqlite.Movie
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }

        public MovieContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(MovieDatabase.DataSource());
        }
    }
}
