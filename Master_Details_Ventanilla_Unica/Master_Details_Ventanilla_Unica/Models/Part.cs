using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class Part
    {
        public int PartId { get; set; }
        public int WordOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public string DocumentItemCode { get; set; }
        public string DocumentItemName { get; set; }
        public string Note { get; set; }
        public bool IsInstalled { get; set; 
        }
    }
}