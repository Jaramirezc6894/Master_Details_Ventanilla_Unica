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
    public class PartConfiguration: EntityTypeConfiguration<Part>
    {
        public PartConfiguration()
        {
            Property(p => p.DocumentItemCode)
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_Part",2) { IsUnique = true }));

            Property(p=>p.WordOrderId)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_Part", 1) { IsUnique = true }));

            Property(p => p.DocumentItemName)
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.Note)
                .HasMaxLength(255)
                .IsOptional();
                
        }
    }
}