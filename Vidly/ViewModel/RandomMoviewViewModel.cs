using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class RandomMoviewViewModel
    {
        public List<Customer> Customers { get; set; }
        public Movie Movie { get; set; }
    }
}