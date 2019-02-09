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
            var viewModel = new CustomerFormViewModel();
            viewModel.MembershipTypes = _context.MembershipTypes.ToList();
            viewModel.Customer = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
            return View("New" , viewModel);
        }

        public List<Customer> GetCustomers()
        {
            var customers = _context.Customers.Include(x=>x.MembershipType).ToList();
            return customers;

        }

        public  ActionResult New()
        {
            var viewModel = new CustomerFormViewModel();
            viewModel.MembershipTypes = _context.MembershipTypes.ToList(); 
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if(viewModel.Customer.Id==0)
            {
                _context.Customers.Add(viewModel.Customer);
                _context.SaveChanges();
            }
            else
            {
                var dataInDb = _context.Customers.SingleOrDefault(x => x.Id == viewModel.Customer.Id);
                dataInDb.Name = viewModel.Customer.Name;
                dataInDb.BirthDate = viewModel.Customer.BirthDate;
                dataInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                dataInDb.isSubscribedToNewsletter = viewModel.Customer.isSubscribedToNewsletter;
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index", "Customers");

        }



    }
}