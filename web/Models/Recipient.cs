using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Recipient
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}