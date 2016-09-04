using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.Dtos;

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

        // POST /api/createrental
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRental)
        {

            return Ok();
        }
    }
}
