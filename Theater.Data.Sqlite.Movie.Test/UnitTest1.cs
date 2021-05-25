using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Theater.Data.Sqlite.Movie.Repository;
using DOM = Theater.Domain.Movie;

namespace Theater.Data.Sqlite.Movie.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestAddMovie()
        {
            var name = Guid.NewGuid().ToString();
            MovieRepository repository = new MovieRepository();
            DOM.Movie movie = new DOM.Movie
            {
                MovieName = name
            };
            var m = await repository.CreateAsync(movie);
            Assert.IsTrue(repository.IsMovieExisted(movie.MovieName).Result);
        }

        [TestMethod]
        public async Task TestAddTheater()
        {
            var name = Guid.NewGuid().ToString();
            MovieRepository repository = new MovieRepository();
            DOM.Theater theater = new DOM.Theater
            {
                Name = name
            };
            var t = await repository.CreateAsync(theater);
            Assert.IsTrue(repository.IsTheaterExisted(t.Name).Result);
        }
    }
}
