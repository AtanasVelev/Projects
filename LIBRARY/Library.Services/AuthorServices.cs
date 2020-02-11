using Library.Data;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class AuthorServices 
    {
        private readonly LibraryContext db;

        public AuthorServices()
        {
            this.db = new LibraryContext();
        }

        public IEnumerable<Book> GetBooks(int id)
        {
            var author = this.db.Authors.Find(id);
            return author.Books.ToArray();
        }

        public void AddAuthor(string Name, Gender Gender, int YearOfBirth)
        {
            var author = new Author() { Name = Name, Gender = Gender, YearOfBirth = YearOfBirth };
            db.Authors.Add(author);
            db.SaveChanges();

        }
        public IEnumerable<Author> GetAllAuthors()
        {
            return db.Authors;
        }
        public void DeleteAuthor(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                throw new KeyNotFoundException("There is not an author with this id");
            }
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        public void UpdateAuthor(int id, string name, int yearOfBirth, Gender gender)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                throw new KeyNotFoundException("There is not an author with this id");
            }
            author.Name = name;
            author.YearOfBirth = yearOfBirth;
            author.Gender = gender;

            db.SaveChanges();
        }
    }
}
