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

            // let user rent same movie
            foreach (var rentMovieId in newRental.MovieIds)
            {
                var movie = _context.Movies.Single(m => m.Id == rentMovieId);

                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

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

            // user can't rent same movie
            //var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //foreach (var movie in movies)
            //{
            //    if (movie.NumberAvailable == 0)
            //        return BadRequest("Movie is not available.");

            //    movie.NumberAvailable--;

            //    var rental = new Rental()
            //    {
            //        Customer = customer,
            //        Movie = movie,
            //        DateRented = DateTime.Now
            //    };

            //    _context.Rentals.Add(rental);
            //}

            //_context.SaveChanges();

            //return Ok();
        }
    }
}
