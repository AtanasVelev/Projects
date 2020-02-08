using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; } 

        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        public int PagesNum { get; set; }

        [Range(1, int.MaxValue)]
        public int ReleaseYear { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
       
        public virtual ICollection<BookCustomer> BookCustomers { get; set; }
    }
}
