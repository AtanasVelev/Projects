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
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int EGN { get; set; }

        [Required]
        public long IDcard { get; set; }

        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BookCustomer> BookCustomers { get; set; }
        public Customer()
        {
        }
      
    }
}
