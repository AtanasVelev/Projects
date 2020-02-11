using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookCustomer
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }

        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
    }
}
