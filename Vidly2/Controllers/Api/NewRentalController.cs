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

        // GET /api/newrental/
        public IHttpActionResult NewRental()
        {


            return Ok();
        }

        // POST /api/CreateNewRentals
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {           

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //This is the same as SQL query:
            //SELECT * FROM movies WHERE Id IN(1,2,3),
            //which is like: select every movie Id of which is in the newRental.MoviesIds list.
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
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
