using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class Labor
    {
        public int LaborId { get; set; }
        public int WordOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public string ServiceItemCode { get; set; }
        public string ServiceItemName { get; set; }
        public decimal LaborHours { get; set; }
        public string Notes { get; set; }
    }
}