using Library.Models;
using System.Data.Entity;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryDb")
        {
        }

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<BookCustomer> BookCustomers { get; set; }
    }
}
