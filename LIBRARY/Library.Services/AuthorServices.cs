using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Data;

namespace Library.Services
{
    public class AuthorServices
    {
        public LibraryContext Db { get; set; }

        public AuthorServices()
        {
            this.Db = new LibraryContext();
        }
        public void AddAuthor(string Name, Gender Gender, int YearOfBirth)
        {
            var author = new Author() { Name = Name, Gender = Gender, YearOfBirth = YearOfBirth };
            Db.Authors.Add(author);
            Db.SaveChanges();

        }
    }
}
