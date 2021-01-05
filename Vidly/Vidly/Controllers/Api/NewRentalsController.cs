using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Dtos;
using Vidly.Models;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieId.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            
            _context.SaveChanges();

            return Ok();
        }

        //// POST /api/customers
        //[HttpPost]
        //public IHttpActionResult CreateRentalForm(RentalFormDto rentalFormDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var rentalForm = Mapper.Map<RentalFormDto, RentalForm>(rentalFormDto);

        //    _context.RentalForms.Add(rentalForm);
        //    _context.SaveChanges();

        //    rentalFormDto.Id = rentalForm.Id;

        //    return Ok();
        //}

        //[HttpPost]
        //public JsonResult SearchCustomer(string prefix)
        //{
        //    var allCustomers = _context.Customers.ToList();
        //    var movies = _context.Movies.ToList();

        //    //Searching records from list using LINQ query  
        //    var customerList = (from c in allCustomers
        //        where c.Name.StartsWith(prefix)
        //        select new { c.Name });
        //    return Json(customerList, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    customerDto.Id = customer.Id;

        //    return Ok();
        //}
    }
}
