using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Models
{
    public class Author
    {
        private ICollection<Book> books;
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public int YearOfBirth { get; set; }
        public Author()
        {
            this.books = new HashSet<Book>();
        }
        
        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
