using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RentalFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public byte CustomerId { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Required]
        public IEnumerable<byte> MovieId { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}