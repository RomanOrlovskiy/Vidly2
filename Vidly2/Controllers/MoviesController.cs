using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {

            var movies = GetMovies();
            
            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie {Name = "Shrek", Id = 1},
                new Movie {Name = "Wall-e", Id = 2 }
            };

            return movies;
        }
        public ActionResult Details(int id)
        {
            var movies = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1" },
        //        new Customer {Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}
        // /movies
        //If pageIndex is not specified we dispaly the first page.
        //If sortBy is null, we sort by name.
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" +month);
        }
    }
}