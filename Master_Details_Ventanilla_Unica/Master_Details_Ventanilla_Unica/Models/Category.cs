using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<ServiceItem> ServiceItems { get; set; }
        public virtual List<DocumentItem> DocumentItems{ get; set; }
        
    }
}