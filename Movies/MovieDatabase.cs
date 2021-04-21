using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        static MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        /// <summary>
        /// Gets all the movies in the database
        /// </summary>
        public static IEnumerable<Movie> All { get { return movies; } }

        public static IEnumerable<Movie> Search(string terms)
        {
            List<Movie> results = new List<Movie>();

            //null check
            if(terms == null)
            {
                return All;
            }

            foreach(Movie movie in All)
            {
                //Add the movie is the title is a match
                if (movie.Title != null && movie.Title.Contains(terms, StringComparison.CurrentCultureIgnoreCase))
                {
                    results.Add(movie);
                }
            }

            return results;
        }
    }
}
