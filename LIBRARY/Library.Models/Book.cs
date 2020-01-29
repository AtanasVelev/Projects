using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; } //Primary Key 
        public string Title { get; set; }
        public int PagesNum { get; set; }
        public int ReleaseYear { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string AuthorId { get; set; } // Foreign Key - връзка Автор-Книга 1 към МНОГО
        public virtual Author Author { get; set; }
        // Navigational Property виртуално - може да му се смени поведението. Прави се, за да достъпваме Авторът, към който тази книга е закачена.

    }
}
