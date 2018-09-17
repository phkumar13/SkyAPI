using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyAPI.Models
{
    public class Movie : IMovieService
    {
        public int    Id { get; set; }
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public string ParentalControlLevel { get; set; }

        public Movie()
        {
        }

        protected IEnumerable<Movie> getMoviesList()
        {
            // This method is returning a static list.
            // However, this needs to fetch from a dictionary in the database.
            List<Movie> Movies = new List<Movie>()
            {
                new Movie { Id = 1,  MovieId = "A", MovieName = "Movie 1",  ParentalControlLevel = "U"  },
                new Movie { Id = 2,  MovieId = "B", MovieName = "Movie 2",  ParentalControlLevel = "PG" },
                new Movie { Id = 3,  MovieId = "C", MovieName = "Movie 3",  ParentalControlLevel = "12" },
                new Movie { Id = 4,  MovieId = "D", MovieName = "Movie 4",  ParentalControlLevel = "15" },
                new Movie { Id = 5,  MovieId = "E", MovieName = "Movie 5",  ParentalControlLevel = "18" },
                new Movie { Id = 6,  MovieId = "F", MovieName = "Movie 6",  ParentalControlLevel = "U"  },
                new Movie { Id = 7,  MovieId = "G", MovieName = "Movie 7",  ParentalControlLevel = "PG" },
                new Movie { Id = 8,  MovieId = "H", MovieName = "Movie 8",  ParentalControlLevel = "12" },
                new Movie { Id = 9,  MovieId = "I", MovieName = "Movie 9",  ParentalControlLevel = "15" },
                new Movie { Id = 10, MovieId = "I", MovieName = "Movie 10", ParentalControlLevel = "18" }
            };

            return Movies;
        }

        public string getParentalControlLevel(string movieId)
        {
            var Movies = getMoviesList();

            var movies = Movies.Where(p => p.MovieId == movieId.ToUpper());
            if (movies.Count() > 1)
            {
                Exception ex = new Exception("Technical Failure Exception");
                return ex.ToString();
            }

            var movie = Movies.Where(p => p.MovieId == movieId.ToUpper()).FirstOrDefault();
            if (movie == null)
            {
                Exception ex = new Exception("Title Not Found Exception");
                return ex.ToString();
            }

            return movie.ParentalControlLevel;
        }

    }
}