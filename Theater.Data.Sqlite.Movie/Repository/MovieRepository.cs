using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Data.Sqlite.Movie.Mapper;
using Theater.Repository.Movie;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Theater.Repository;
using dom = Theater.Domain;

namespace Theater.Data.Sqlite.Movie.Repository
{
    public class MovieRepository : IMovieRepository ,ITheaterRepository
    {
        private MovieContext movieContext = new MovieContext();

        public MovieRepository() { }

        public async Task<Domain.Movie.Movie> CreateAsync(Domain.Movie.Movie model)
        {
            if (model != null)
            {
                await this.movieContext.Movies.AddAsync(new MovieMapper(model).Destination);
                await this.movieContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }

        public async Task<Domain.Movie.Theater> CreateAsync(Domain.Movie.Theater model)
        {
            if (model != null)
            {
                await this.movieContext.Theaters.AddAsync(new TheaterMapper(model).Destination);
                await this.movieContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }

        public async Task<List<dom.Movie.Movie>> GetAll()
        {
            List<Domain.Movie.Movie> result = new List<Domain.Movie.Movie>();
            List<Movie> movies = await this.movieContext.Movies.ToListAsync(); ;

            if (movies != null)
            {
                foreach (var m in movies)
                {
                    result.Add(new MovieDataMapper(m).Destination);
                }
            }
            return result;
        }

        public async Task<List<Domain.Movie.Movie>> GetMovies(string movie)
        {
            List<Domain.Movie.Movie> result = new List<Domain.Movie.Movie>();
            List<Movie> movies = null;

            if (!string.IsNullOrEmpty(movie))
            {
                movies = await this.movieContext.Movies.Where(p => p.Name.Contains(movie)).ToListAsync();
            }
            else
            {
                movies = await this.movieContext.Movies.ToListAsync();
            }

            if (movies != null)
            {
                foreach (var m in movies)
                {
                    result.Add(new MovieDataMapper(m).Destination);
                }
            }
            return result;
        }

        public async Task<List<Domain.Movie.Theater>> GetTheaters(string theater)
        {
            List<Domain.Movie.Theater> result = new List<Domain.Movie.Theater>();
            List<Theater> theaters = null;

            if (!string.IsNullOrEmpty(theater))
            {
                theaters = await this.movieContext.Theaters.Where(p => p.Name.Contains(theater)).ToListAsync();
            }
            else
            {
                theaters = await this.movieContext.Theaters.ToListAsync();
            }

            if (theaters != null)
            {
                foreach (var t in theaters)
                {
                    result.Add(new TheaterDataMapper(t).Destination);
                }
            }
            return result;
        }

        public async Task<bool> IsMovieExisted(string movie)
        {
            var m = await this.movieContext.Movies.FirstOrDefaultAsync(p => p.Name == movie);
            return m != null;
        }

        public async Task<bool> IsTheaterExisted(string theater)
        {
            var t = await this.movieContext.Theaters.FirstOrDefaultAsync(p => p.Name == theater);
            return t != null;
        }

        public Task<Domain.Movie.Movie> UpdateAsync(Domain.Movie.Movie modify)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Movie.Theater> UpdateAsync(Domain.Movie.Theater modify)
        {
            throw new NotImplementedException();
        }
    }
}
