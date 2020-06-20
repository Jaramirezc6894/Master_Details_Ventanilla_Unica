using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class ServiceItem
    {
        public int ServiceItemId { get; set; }
        public string ServiceItemCode { get; set; }
        public string ServiceItemName { get; set; }
        //public HttpPostedFileBase File { get; set; }
        public byte[] FileServiceItem { get; set; }
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public DateTime FechaSubida { get; set; }


    }
}