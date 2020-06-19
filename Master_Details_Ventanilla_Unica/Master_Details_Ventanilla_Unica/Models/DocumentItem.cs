using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Services.Description;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class DocumentItem
    {
        public int DocumentIteId { get; set; }
        public string DocumentItemCode { get; set; }
        public string DocumentItemName { get; set; }
        public byte[] FileDocumentItem { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}