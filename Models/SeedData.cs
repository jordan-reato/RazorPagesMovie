using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {
                // look for any existing movies
                if (context.Movie.Any())
                {
                    return; // database already seeded, return nothing
                }

                // database hasn't yet been seeded, add all the movies
                context.Movie.AddRange(
                    new Movie {
                        Title = "When Harry Met Sally",
                        ReleaseDate = new DateTime(1983, 02, 12),
                        Genre = "Horror",
                        Price = 7.99M,
                        Rating = "PG"
                    },
                    new Movie {
                        Title = "Ghost Busters",
                        ReleaseDate = new DateTime(1984, 02, 12),
                        Genre = "Horror",
                        Price = 6.99M,
                        Rating = "M"
                    },
                    new Movie {
                        Title = "Ghost Busters 2",
                        ReleaseDate = new DateTime(1985, 02, 12),
                        Genre = "Horror",
                        Price = 7.50M,
                        Rating = "MA"
                    },
                    new Movie {
                        Title = "Alien 1",
                        ReleaseDate = new DateTime(1999, 02, 12),
                        Genre = "Horror",
                        Price = 6.87M,
                        Rating = "R"
                    },
                    new Movie {
                        Title = "Alien 2",
                        ReleaseDate = new DateTime(1998, 02, 12),
                        Genre = "Horror",
                        Price = 9.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}