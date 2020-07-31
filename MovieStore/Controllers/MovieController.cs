using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using MovieStore.Services;
using System.Collections.Generic;

namespace MovieStore.Controllers
{
    public class MovieController : ControllerBase
    {
        public JSonFileMoviesService MovieService { get; }
        public MovieController(JSonFileMoviesService movieService)
        {
            MovieService = movieService;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return MovieService.GetMovies();
        }
    }
}