using Master_Details_Ventanilla_Unica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.DataLayer
{
    public class WorkOrderConfiguration:EntityTypeConfiguration<WorkOrder>
    {
        public WorkOrderConfiguration()
        {
            Property(w => w.OrderDateTime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(w => w.Description).HasMaxLength(256).IsOptional();
            Property(w => w.CertificationReuirements).HasMaxLength(256).IsOptional();


        }
    }
}