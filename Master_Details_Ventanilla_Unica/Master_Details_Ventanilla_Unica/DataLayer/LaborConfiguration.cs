using Master_Details_Ventanilla_Unica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.DataLayer
{
    public class LaborConfiguration:EntityTypeConfiguration<Labor>
    {
        public LaborConfiguration()
        {

            Property(l => l.ServiceItemCode)
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_Labor",2) { IsUnique = true }));

            Property(l => l.WordOrderId)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_Labor", 1)));

            Property(l => l.ServiceItemName)
                .HasMaxLength(255)
                .IsRequired();

            Property(l => l.LaborHours).HasPrecision(18, 2);

            Property(l => l.Notes).HasMaxLength(255).IsOptional();

        }
    }
}