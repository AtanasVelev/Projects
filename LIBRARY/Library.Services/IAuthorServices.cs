using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public interface IAuthorServices
    {
        void AddAuthor(string Name, Gender Gender, int YearOfBirth);
        void DeleteAuthor(int id);
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Book> GetBooks(int id);
        void UpdateAuthor(int id, string name, int yearOfBirth, Gender gender);
    }
}