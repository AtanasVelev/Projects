using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class BookServices
    {
        private readonly LibraryContext db;

        public BookServices()
        {
            this.db = new LibraryContext();
        }
        public bool IsRented(int bookId)
        {
          var bookInfo =  this.db.BookCustomers.FirstOrDefault(bookCustomer => bookCustomer.DateFrom < DateTime.Now 
            && DateTime.Now < bookCustomer.DateTo 
            && bookCustomer.BookId == bookId);

            return bookInfo == null ? false : true;
        }

        public Book GetBookById(int id)
        {
            return db.Books.Find(id);
        }

        public IQueryable<Book> GetAvailableBooks()
        {
            return this.db.BookCustomers
                .GroupBy(x=>x.BookId).Where(group => group.Max(x=>x.DateTo) < DateTime.Now)
                .Select(x=>x.First().Book);
        }

        public void UpdateBook(int id, string title, int pagesNum, int releaseYear, int authorId)
        {
            Book book = db.Books.Find(id);

            if (book == null)
            {
                throw new KeyNotFoundException("There is no book with this id");
            }

            book.Title = title;
            book.PagesNum = pagesNum;
            book.ReleaseYear = releaseYear;
            book.AuthorId = authorId;

            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }
        public IQueryable<Book> GetAllBooks()
        {
            return db.Books;
        }

        public void AddBook(int authorId, string title, int pagesNum, int releaseYear)
        {
            var book = new Book() { AuthorId = authorId, Title = title, PagesNum = pagesNum, ReleaseYear = releaseYear };
            db.Books.Add(book);
            db.SaveChanges();
        }
    }
}
