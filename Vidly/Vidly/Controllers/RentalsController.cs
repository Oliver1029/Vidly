using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var customers = _context.Customers.ToList();
            var movies = _context.Movies.ToList();
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new RentalFormViewModel()
            {
                Customers = customers,
                Movies = movies,
                MembershipTypes = membershipTypes
            };

            return View("RentalForm", viewModel);
        }

        [HttpPost]
        public JsonResult SearchCustomer(string prefix)
        {
            var allCustomers = _context.Customers.ToList();
            var movies = _context.Movies.ToList();

            //Searching records from list using LINQ query  
            var customerList = (from c in allCustomers
                where c.Name.StartsWith(prefix)
                select new { c.Name });
            return Json(customerList, JsonRequestBehavior.AllowGet);
        }
    }
}