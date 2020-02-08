using Library.Services;
using System.Web.Mvc;
using Library.Models;
using System.Linq;

namespace Library.MVCClient.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorServices service;

        public AuthorsController()
        {
            service = new AuthorServices();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetBooks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBooks(Author author)
        {
            Book[] books = service.GetBooks(author.Id).ToArray();

            ViewBag.Books = books;

            return View("ReturnBooks");
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(int id, string name, int yearOfBirth, Gender Gender) // да се махне полът да се едитва
        {
            service.UpdateAuthor(id, name, yearOfBirth, Gender);
            return View("Updated");
        }

        [HttpPost]
        public ActionResult AddBookToAuthor(int id, string name, int yearOfBirth, Gender Gender)
        {
            service.UpdateAuthor(id, name, yearOfBirth, Gender);
            return View("Updated");
        }

        [HttpGet]
        public ActionResult DeleteAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteAuthor(Author author)
        {
            service.DeleteAuthor(author.Id);
            return View("Deleted");
        }
        public ActionResult GetAll()
        {
            var authors = service.GetAllAuthors();
            ViewBag.Authors = authors.ToArray();

            return View("GetAll");

        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(string Name, int yearOfBirth, Gender Gender)
        {

            service.AddAuthor(Name, Gender, yearOfBirth);
            return View("Added");
        }
    }
}