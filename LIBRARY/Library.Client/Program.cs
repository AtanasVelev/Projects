using Library.Data;
using Library.Data.Migrations;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LibraryContext, Configuration>());

            var author = new AuthorServices();
         // author.AddAuthor("Ivan Popov", Gender.Male, 1998);
            var author2 = new AuthorServices();
         //  author2.AddAuthor("Antoan Elenkov", Gender.Male, 1990);
            var author3 = new AuthorServices();
            // author3.AddAuthor("Georgi Atanasov", Gender.Male, 1966);


            var book1 = new BookServices();
            //book1.AddBook(1, "Zelenoto Ezero", 206, 2006);
            var customer1 = new CustomerServices();
            //customer1.AddCustomer("Velichka Blagoeva", 123786435, "Atanas Ishirkov street", Gender.Female, 0978654532, "vilitY@abv.bg");
           // customer2.UpdateCustomer(2, "Velichka Blagoeva", 123786435, "Atanas Ishirkov street", Gender.Female, 0978654532, "vilitY@abv.bg");

            var book = new BookServices();
            //book.UpdateBook(3, "Fitnezz made easy", 10000, 1998);
            
        }
       
    }
}
