using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = GetMovies();
            var moviesViewModel = new MoviesViewModel() { Movies = movies };
            return View(moviesViewModel);
        }


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

       

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public List<Movie> GetMovies()
        {
            var movies = _context.Movies.Include(c => c.Genere).ToList();
            return movies;
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Where(x => x.Id == id).Include(c=>c.Genere).SingleOrDefault();
            return View(movie);
        }

    }
}