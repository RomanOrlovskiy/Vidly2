﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity; //for .Include()
using Vidly2.ViewModels;

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

        //Model Binding.
        //Because the model behind the View is of a type 
        //CustomerFormViewModel we can use this type here as a parameter and
        //MVC Framework will automatically map request data to this
        //object. This is called Model Binding. So MVC binds 
        //veiwModel model to the request data that is sent by
        //the user when he submits a form at Customer/New. 
        //*****
        //BUT! We could also set it as a Customer object because
        //in the View of /Customers/New we prefix all the keys
        //in form data as Customer (Customer.Name,Customer.Birthday, etc).
        //*****
        //Set a breakpoint at "return View()" and rerun the app.
        //Go to /Customer/New and fill the form and click Save.
        //Then inspect the content ov viewModel. It will correspond
        //to the data set in Customer/New.
        [HttpPost]//Makes sure this is ONLY called by POST, not GET
        public ActionResult Create(Customer customer)
        {
            #region Add this customer to a Database
            //To add this customer to a Database we, first, have
            //to add it to "_context", but this only writes customer 
            //to memory, not database.
            //To persist any changes to the database (like adding,
            //deleting, changing one of its objects) we have to 
            //use "_customer.SaveChanges();". This triggers 
            //the process of finding out what changes were made
            //and running those changes on the database by automatically
            //creating necessary SQL statements.
            //All these statements are wraped in a transaction, so either all 
            //changes go through, or none.            
            #endregion

            _context.Customers.Add(customer);

            _context.SaveChanges();

            //Here we redirect the user back to the list of customers
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            
            //As we will need to pass more than one type of data to this view
            //it is necessary to create ViewModel that encapsulates needed types. 
            return View(viewModel);
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