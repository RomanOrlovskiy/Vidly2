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

        //Only user with role CanManageMovies should be able to access this action
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {                
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            #region Data Validation
            /* 
                 When the customer object is recieved with some data from
                 a user, ASP.NET MVC checks whether that object is valid
                 based on the data annotations applied on the various 
                 properties of this class. 
                 To get access to validation data we can use property 
                 ModelState.
                 3 steps for data validation:
                 1) add restricting attributes on the properties of the 
                    respected class, Customer in this case,
                 2) use ModelState.IsValid to check whether user provided
                    valid form
                 3) add validation messages in the CustomerForm that will
                    tell user what has gone wrong.
                 */
            #endregion

            #region Section 5 Exercise
            /*Section 5 Exercise
              1. 3 steps for data validation:
                1) add restricting attributes on the properties of the 
                respected class, Movie in this case,
                2) use ModelState.IsValid to check whether user provided
                valid form,
                3) add validation messages in the MovieForm that will
                tell user what has gone wrong if id did,
                4) change the color of error messages,
                5) use Html.ValidationSummary().
              2. Enable client-side validation.
              3. Enable anti-forgery deffense.                          
             */
            #endregion

            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),                    
                };

                return View("MovieForm", viewModel);
            }

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
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            #region .Include
            /*
            .Include(..) is what is called Eager Loading (?).
            It is needed to load customer and its
            MembershipType field together. Need to include 
            System.Data.Entity for .Include() extension method.
             */
            #endregion

            //return View(movies);

            //Update: no need for list anymore as we are going with API,
            // DataTables and jQuery.

            //Depending on the role of the current user, give him respecting View
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();           

            var viewModel = new MovieFormViewModel(movie)
            {
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