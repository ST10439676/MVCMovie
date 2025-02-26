using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data;

public class SeedData {
    public static void Initialize(IServiceProvider serviceProvider) {
        using (var context =
               new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>())) {
            
            // Runs against database if Movie Model has > 0 contents.
            if (context.Movie.Any()) {
                return;
            }
            
            // Movie here is DbSet<Movie> and not Movie.
            // AddRange runs insert on the database.
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    GrossPrice = 7.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    GrossPrice = 8.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    GrossPrice = 9.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    GrossPrice = 3.99M,
                    Rating = "R"
                });
            
            context.SaveChanges();
        }

    }
}