using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoBook.Models

{
    public class RegisterModel
    {
        [Required]

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
    }
}
