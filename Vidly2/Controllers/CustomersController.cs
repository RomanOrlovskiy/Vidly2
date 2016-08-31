using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity; //for .Include()

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {

        /* Steps to get data from database
         To get data from database instead of hard-coded values
        we have to do next :
        1) Declare a private field _context of type ApplicationDbContext.
           This creates new DbContext(database) object.
        2) Add constructor to initialize _context.
        3) Override Dispose method.
        4) Upgrade Index action.
        5) (Manually) Add data to a Customer table in Database.
             */

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Dont forget about deffered execution. ToList helps with it,
            //otherwise this will be only executed during iteration loop.
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            #region .Include
            /*
            .Include(..) is what is called Eager Loading (?).
            It is needed to load customer and its
            MembershipType field together. Need to include 
            System.Data.Entity for .Include() extension method.
             */
            #endregion

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }       

    }
}