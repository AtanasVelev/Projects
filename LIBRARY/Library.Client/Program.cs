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
            var author1 = new Author();
            author1.Name = "Ivan Ivanov";
            author1.YearOfBirth = 1990;
            author1.Gender = Gender.Male;
           

            var book1 = new Book();
            book1.Title = "Zeleno ezero";
            book1.ReleaseYear = 2000;
            book1.PagesNum = 177;
            book1.Author = author1;
           

            var customer1 = new Customer();
            customer1.CustomerName = "Peyo Peev";
            customer1.Address = " \" Ala-Bala street\" ";
            customer1.Email = "ala-bala@gmail.com";
            customer1.Gender = Gender.Female;
            customer1.PhoneNumber = "0898 765 145";
            customer1.IDcard = 13123132332321;

            var newAuthor = new AuthorServices();
            newAuthor.AddAuthor("PopEye", Gender.Male, 1998);
        }
       
    }
}
