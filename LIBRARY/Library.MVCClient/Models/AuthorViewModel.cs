using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.MVCClient.Models
{
    public class AuthorViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsMale { get; set; }

        public int YearOfBirth { get; set; }
    }
}
