using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Purchaser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}