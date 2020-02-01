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

        public void AddBook(int bookId, int authorId)
        {
            var author = this.db.Authors.Find(authorId);
            var book = this.db.Books.Find(bookId);
            if (author == null || book == null)
            {
                throw new KeyNotFoundException("There is no author or book with this id");
            }

            author.Books.Add(book);
            db.SaveChanges();
        }
        public void AddAuthor(string Name, Gender Gender, int YearOfBirth)
        {
            var author = new Author() { Name = Name, Gender = Gender, YearOfBirth = YearOfBirth };
            db.Authors.Add(author);
            db.SaveChanges();

        }
        public IQueryable<Author> GetAllAuthors()
        {
           return db.Authors;
        }
        public void DeleteAuthor(int id)
        {
            Author author = db.Authors.Find(id);
            // check if author exists
            db.Authors.Remove(author);
            db.SaveChanges();
        }
        public void UpdateAuthor(int id, string name, int birthYear, Gender gender)
        {
            Author author = db.Authors.Find(id);
            // add validation
            author.Name = name;
            author.YearOfBirth = birthYear;
            author.Gender = gender;

            db.SaveChanges();
        }
    }
}
