using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string AccoutNumber { get; set; }
        public string CompanyName { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}