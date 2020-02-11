using Library.Models;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.MVCClient.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookServices booksService;
        private readonly BookCustomerServices booksCustomerService;

        public BooksController()
        {
            booksService = new BookServices();
            booksCustomerService = new BookCustomerServices();
        }
        [HttpGet]
        public ActionResult IsRented()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IsRented(int id)
        {
            return View("ReturnIsRented", booksService.IsRented(id));
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReturnBookInfo()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetAllRentedForPeriod()
        {
            var currentYear = DateTime.Now.Year;
            var booksRentedCount = new List<int>();
            for (int month = 1; month <= 12; month++)
            {
                booksRentedCount.Add( booksCustomerService.GetAllBooksRentedForPeriod(currentYear, month));
            }

            ViewBag.Books = booksRentedCount;

            return View("GetAllRentedForPeriod");
        }

        [HttpGet]
        public ActionResult GetAllAvailable()
        {
            var books = booksService.GetAvailableBooks();
            ViewBag.Books = books.ToArray();

            return View("GetAll");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var books = booksService.GetAllBooks();
            ViewBag.Books = books.ToArray();

            return View();
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetBook(Book book)
        {
            return View("ReturnBookInfo", booksService.GetBookById(book.Id));
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(int id, string title, int pagesNum, int releaseYear, int authorId)
        {
            booksService.UpdateBook(id, title, pagesNum, releaseYear, authorId);
            return View("Updated");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            booksService.DeleteBook(book.Id);
            return View("Deleted");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Add(int authorId, string title, int releaseYear, int pagesNum)
        {

            booksService.AddBook(authorId, title, releaseYear, pagesNum); 

            return View("Added");
        }
    }
}