using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity; //for .Include()
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /*Section 4 Exercise:         
         1) Make a form to create a new Movie:
            - create DbSet in IdentityModels to get access to Genres table
            - create NewMovieViewModel for New action,
            - change labels of the Movie class to display properly.            
         2) Create a button "Add Movie" on the /Index page which is a link
            to a Movies/New to create a new movie.
         3) Create saving logic for a new movie.
         4) Update editing logic for an existing movie.
             */
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {            
            if (movie.Id == 0)
            {
                //add new movie
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                //look for existing movie and update it
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
            }
                       
            try
            {
                //To deal with this error move [Required] attribute from
                //Genre property to GenreId property in Movie.cs 
                _context.SaveChanges();
            }
            catch (DbEntityValidationException y)
            {
                Console.WriteLine(y);
            }
            catch (DbUpdateException e)
            {
                //This triggers because in my MovieForm view I used for drop-down list
                //m.Movie.Genre when it should be m.Movie.GenreId.
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            #region .Include
            /*
            .Include(..) is what is called Eager Loading (?).
            It is needed to load customer and its
            MembershipType field together. Need to include 
            System.Data.Entity for .Include() extension method.
             */
            #endregion

            return View(movies);
        }
       
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();           

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            
            return View("MovieForm", viewModel);
        }

        //Older stuff: Edit, Random, Index
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

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