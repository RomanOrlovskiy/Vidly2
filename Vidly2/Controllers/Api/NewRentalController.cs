using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.Dtos;
using System.Data.Entity;

namespace Vidly2.Controllers.Api
{
    
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST /api/CreateNewRentals
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            #region Edge cases
            //Edge cases.
            //There are two approaches to dealing with edge cases: deffensive
            //and optimistic. Deffensive is mostly used for public API's to 
            //handle each possible edge cases and give back the user specific 
            //message to the error. THe problem is that it increases the complexity
            //of the code and as result its maintainability in the future.
            //Optimistic approach on the other hand is less troublesome.
            //Like in this case, instead of dealing with 4 edge cases, you may
            //only deal with the most important one.

            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No movie ids have been given.");

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more movieIds are invalid.");
            #endregion

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            //This is the same as SQL query:
            //SELECT * FROM movies WHERE Id IN(1,2,3),
            //which is like: select every movie Id of which is in the newRental.MoviesIds list.
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
