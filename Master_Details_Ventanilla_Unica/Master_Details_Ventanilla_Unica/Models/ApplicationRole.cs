using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Master_Details_Ventanilla_Unica.Models
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name):base(name)
        {

        }
    }
}