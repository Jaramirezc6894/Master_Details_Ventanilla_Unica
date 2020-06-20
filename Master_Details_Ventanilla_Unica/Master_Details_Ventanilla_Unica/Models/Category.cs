using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using Master_Details_Ventanilla_Unica.Models;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<DocumentItem> DocumentItems { get; set; }
        public virtual List<ServiceItem> ServiceItems { get; set; }

    }
}