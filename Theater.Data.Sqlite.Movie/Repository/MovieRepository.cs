using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Theater.Data.Sqlite.Movie.Mapper;
using Theater.Repository.Movie;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

            Task<List<Domain.Movie.Movie>> task = new Task<List<Domain.Movie.Movie>>(() =>
            {
                if (movies != null)
                {
                    foreach (var m in movies)
                    {
                        result.Add(new MovieDataMapper(m).Destination);
                    }
                }
                return result;
            });

            return await task;
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

            Task<List<Domain.Movie.Theater>> task = new Task<List<Domain.Movie.Theater>>(() =>
            {
                if (theaters != null)
                {
                    foreach (var t in theaters)
                    {
                        result.Add(new TheaterDataMapper(t).Destination);
                    }
                }
                return result;
            });            

            return await task;
        }

        public async Task<bool> IsMovieExisted(string movie)
        {
            if (!string.IsNullOrEmpty(movie))
            {
                var m = await this.movieContext.Movies.FirstOrDefaultAsync(p => p.Name == movie);
                return m != null;
            }
            throw new ArgumentException("Movie cannot be empty");
        }

        public async Task<bool> IsTheaterExisted(string theater)
        {
            if (!string.IsNullOrEmpty(theater))
            {
                var t = await this.movieContext.Theaters.FirstOrDefaultAsync(p => p.Name == theater);
                return t != null;
            }
            throw new ArgumentException("Theater cannot be empty");
        }

        public async Task<Domain.Movie.Movie> UpdateAsync(Domain.Movie.Movie model)
        {
            if (model != null)
            {
                this.movieContext.Movies.Update(new MovieMapper(model).Destination);
                await this.movieContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }

        public async Task<Domain.Movie.Theater> UpdateAsync(Domain.Movie.Theater model)
        {
            if (model != null)
            {
                this.movieContext.Theaters.Update(new TheaterMapper(model).Destination);
                await this.movieContext.SaveChangesAsync();
                return model;
            }
            throw new ArgumentException("Model is null");
        }
    }
}
