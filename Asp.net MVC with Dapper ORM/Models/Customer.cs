using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.net_MVC_with_Dapper_ORM.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}