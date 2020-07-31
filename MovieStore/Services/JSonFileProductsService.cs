using Microsoft.AspNetCore.Hosting;
using MovieStore.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MovieStore.Services
{
    public class JSonFileProductsService
    {
        public JSonFileProductsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        //This gets the json file at the root of the directory
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "movies.json"); }
        }

        public IEnumerable<Movie> GetMovies()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Movie[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string movieId, int rating)
        {
            var movies = GetMovies();

            if (movies.First(x => x.Id == movieId).Ratings == null)
            {
                movies.First(x => x.Id == movieId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = movies.First(x => x.Id == movieId).Ratings.ToList();
                ratings.Add(rating);
                movies.First(x => x.Id == movieId).Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Movie>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    movies
                );
            }
        }
    }
}
