using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MovieStore.Models;
using MovieStore.Services;
using System.Collections.Generic;

namespace MovieStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JSonFileMoviesService MoviesService;

        public IEnumerable<Movie> Movies { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JSonFileMoviesService moviesService)
        {
            _logger = logger;
            MoviesService = moviesService;
        }

        public void OnGet()
        {
            Movies = MoviesService.GetMovies();
        }
    }
}
