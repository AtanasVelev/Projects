using Library.Models;
using Library.Services;
using System.Web.Mvc;
using System.Linq;
using System;
using Library.MVCClient.Models;
using System.Web;

namespace Library.MVCClient.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerServices booksService;
        private readonly BookCustomerServices booksCustomersService;

        public CustomersController()
        {
            booksService = new CustomerServices();
            booksCustomersService = new BookCustomerServices();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var customers = booksService.GetAllCustomers();
           ViewBag.Customers= customers.ToArray();
            return View("GetAll");

        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            booksService.DeleteCustomer(customer.CustomerId);
            return View("Deleted");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CustomerViewModel model)
        {
            booksService.AddCustomer(model.Name, model.IDcard, model.Address, 
                model.IsMale ? Gender.Male : Gender.Female, model.PhoneNumber, model.Email,model.EGN);
            return View("Added");
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(int customerid, string name,long egn, long idCard, string address, Gender gender, int phoneNumber, string email) 
            // да се махне полът да се едитва И 
        {
            booksService.UpdateCustomer(customerid, name, egn,idCard, address, gender, phoneNumber, email);
            return View("Updated");
        }

        [HttpGet]
        public ActionResult RentABook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RentABook(BookCustomer bookCustomer)
        {
            if (!ModelState.IsValid) throw new HttpException("Invalid parameters passed");

            booksCustomersService.RentABook(bookCustomer.BookId,bookCustomer.CustomerId, bookCustomer.DateFrom,bookCustomer.DateTo);
            return View("RentABookSuccessfull");
        }
    }
}