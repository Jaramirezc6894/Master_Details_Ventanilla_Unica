using Master_Details_Ventanilla_Unica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Master_Details_Ventanilla_Unica.DataLayer
{
    public class DocumentItemConfiguration:EntityTypeConfiguration<DocumentItem>
    {
        public DocumentItemConfiguration()
        {
            Property(di => di.DocumentItemCode)
                .HasMaxLength(15)
                .IsRequired()
                .HasColumnAnnotation("Index",

                new IndexAnnotation(new IndexAttribute("AK_DocumentItem_DocuementItemCode") { IsUnique = true }));
            Property(di => di.DocumentItemName)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_DocumentItem_DocumentItemName") { IsUnique = true }));
        }
    }
}