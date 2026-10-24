
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<MvcMovieContext>();

            Movie[] movies =
            {
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = new DateTime(1989, 2, 12),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = new DateTime(1984, 3, 13),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = new DateTime(1986, 2, 23),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = new DateTime(1959, 4, 15),
                    Genre = "Western",
                    Price = 3.99M
                }
            };

            foreach (Movie movie in movies)
            {
                if (!context.Movie.Any(m => m.Title == movie.Title))
                {
                    context.Movie.Add(movie);
                }
            }

            context.SaveChanges();
        }
    }
}
