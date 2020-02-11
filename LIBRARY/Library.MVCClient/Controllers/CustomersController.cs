using Library.Models;
using Library.MVCClient.Models;
using Library.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Update(CustomerViewModel model) 
           
        {
            booksService.UpdateCustomer(model.CustomerId,model.Name, model.EGN, model.IDcard, model.Address,
                model.IsMale ? Gender.Male : Gender.Female, model.PhoneNumber, model.Email);
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