using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Chanberlin"},
                new Customer { Id = 2, Name = "Sharon"},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Chanberlin"},
                new Customer { Id = 2, Name = "Sharon"},
            };

            var customer = customers.Where(c => c.Id == id).SingleOrDefault();

            if (customer == null)
            {
                return (HttpNotFound());
            }
            //var customer = customers.Find(c => c.Id == id);

            return View(customer);
        }
    }
}