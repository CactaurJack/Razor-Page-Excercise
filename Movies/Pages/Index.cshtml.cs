using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string[] MPAARatings { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        [BindProperty(SupportsGet = true)]
        string[] Genre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? IMDBMin { get; set; }
        [BindProperty(SupportsGet = true)]
        public double? IMDBMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? RTMin { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? RTMax { get; set; }

        public void OnGet()
        {
            MPAARatings = Request.Query["MPAARatings"];
            SearchTerms = Request.Query["SearchTerms"];
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            Movies = MovieDatabase.FilterByRottenTomatoesRating(Movies, RTMin, RTMax);
        }
    }
}

