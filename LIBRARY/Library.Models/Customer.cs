using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Customer
    {
        private ICollection<Book> books;
        public int Id { get; set; }
        
        public string CustomerName { get; set; }
       
        public long IDcard { get; set; }
        
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Customer()
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
