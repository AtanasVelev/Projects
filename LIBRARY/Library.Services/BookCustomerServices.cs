using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class BookCustomerServices : IBookCustomerServices
    {
        private readonly LibraryContext db;

        public BookCustomerServices()
        {
            this.db = new LibraryContext();
        }

        public void RentABook(int bookId, int customerId, DateTime dateFrom, DateTime dateTo)
        {
            var customer = this.db.Customers.Find(customerId);
            var book = this.db.Books.Find(bookId);
            if (customer == null || book == null)
            {
                throw new KeyNotFoundException("There is not an author or a book with this id");
            }

            db.BookCustomers.Add(new BookCustomer() { BookId = bookId, CustomerId = customerId, DateFrom = dateFrom, DateTo = dateTo });
            db.SaveChanges();
        }
        public int GetAllBooksRentedForPeriod(int year, int month)
        {
            return db.BookCustomers.Where(x => x.DateFrom.Year == year && x.DateFrom.Month == month)
                .GroupBy(x => x.BookId)
                .Count();
        }
    }
}
