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
    public class CustomerConfiguration:EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.AccoutNumber)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("AK_Customer_AccountNumber") { IsUnique = true }));

            Property(c => c.CompanyName).HasMaxLength(50).IsRequired();
            Property(c => c.Addres).HasMaxLength(50).IsRequired();
            Property(c => c.City).HasMaxLength(20).IsRequired();
            Property(c => c.State).HasMaxLength(10).IsRequired();
            Property(c => c.ZipCode).HasMaxLength(20).IsRequired();
            Property(c => c.Phone).HasMaxLength(20).IsRequired();
        }
    }
}