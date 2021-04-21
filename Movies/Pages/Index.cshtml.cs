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
        public string[] MPAARatings { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public string SearchTerms { get; set; }

        public void OnGet()
        {
            MPAARatings = Request.Query["MPAARatings"];
            SearchTerms = Request.Query["SearchTerms"];
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
        }
    }
}
