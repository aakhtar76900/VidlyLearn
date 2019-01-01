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
    public class CustomersController : Controller
    {
        
        private MyDBContext _context;

        public CustomersController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }

        // GET: Customers
        public ActionResult Index()
        {

            var customers = GetCustomers();
            var customersViewModel = new CustomersViewModel() { Customers = customers };
            return View(customersViewModel);
        }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
            return View(customer);
        }

        public List<Customer> GetCustomers()
        {
            var customers = _context.Customers.Include(x=>x.MembershipType).ToList();
            return customers;

        }


    }
}