using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? TargetDateTime { get; set; }
        public DateTime? DropDeadDateTime { get; set; }
        public string Description { get; set; }
        public WorkOrderStatus WordOrderStatus { get; set; }
        public string CertificationReuirements { get; set; }
    }
    public enum WorkOrderStatus
    {
        Created=0,
        InProcess=10,
        Submitted=20,
        Approved=30,
        Canceled=-10,
        Rejected=-20

    }
}