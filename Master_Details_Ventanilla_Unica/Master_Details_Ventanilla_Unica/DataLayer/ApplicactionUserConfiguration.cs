using Master_Details_Ventanilla_Unica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.DataLayer
{
    public class ApplicactionUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicactionUserConfiguration()
        {
            Property(au => au.FirstName).HasMaxLength(15).IsOptional();
        }
    }
}