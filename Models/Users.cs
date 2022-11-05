using System;
using System.Collections.Generic;

namespace EMedicine.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal Fund { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public List<Orders> Orders { get; set; }
        public int OrderId { get; set; }
    }
}
