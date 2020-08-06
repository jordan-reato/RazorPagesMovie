using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public String SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = (
                from movie in _context.Movie
                orderby movie.Genre
                select movie.Genre
            );

            // get movies from movie context
            var Movies = from movie in _context.Movie select movie;

            // apply search string filter
            if (!string.IsNullOrEmpty(SearchString))
            {
                Movies = Movies.Where(movie => movie.Title.Contains(SearchString));
            }

            // apply genre filter
            if (!String.IsNullOrEmpty(MovieGenre))
            {
                Movies = Movies.Where(movie => movie.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await Movies.ToListAsync();
        }
    }
}
