using System.ComponentModel.DataAnnotations;

namespace Library.MVCClient.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long EGN { get; set; }

        [Required]
        public long IDcard { get; set; }

        public string Address { get; set; }
        public bool IsMale { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}