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
            var viewModel = new MovieFormViewModel();
            viewModel.Generes = _context.Generes.ToList();
            viewModel.Movie = _context.Movies.Where(x => x.Id == id).Include(c=>c.Genere).SingleOrDefault();
            return View("New",viewModel);
        }
        
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel();
            viewModel.Generes = _context.Generes.ToList();
            return View(viewModel);
        }

        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if(viewModel.Movie.Id == 0)
            {
                _context.Movies.Add(viewModel.Movie);
                _context.SaveChanges();
            }
            else
            {
                var dataInDb = _context.Movies.Single(x => x.Id == viewModel.Movie.Id);
                dataInDb.Name = viewModel.Movie.Name;
                dataInDb.GenereId = viewModel.Movie.GenereId;
                dataInDb.NumberInStock = viewModel.Movie.NumberInStock;
                dataInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                _context.SaveChanges();
                dataInDb.ReleaseDate = viewModel.Movie.ReleaseDate;

            }

            return RedirectToAction("Index", "Movies");

        }





    }
}