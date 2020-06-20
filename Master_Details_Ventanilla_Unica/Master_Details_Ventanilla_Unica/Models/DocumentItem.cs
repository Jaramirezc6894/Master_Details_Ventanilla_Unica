using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class DocumentItem
    {
        [Key]
        public int DocumentIteId { get; set; }
        public string DocumentItemCode { get; set; }
        public string DocumentItemName { get; set; }
        //public HttpPostedFileBase File { get; set; }
        public byte[] FileDocumentItem { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime FechaSubida { get; set; }

    }
}