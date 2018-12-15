using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>()
            {
                new Customer {Name="Seb"},
                new Customer {Name="Kimi"}
            };

            var viewModel = new RandomMoviewViewModel()
            {
                Movie = movies,
                Customers = customers
            };


            return View(viewModel);

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}