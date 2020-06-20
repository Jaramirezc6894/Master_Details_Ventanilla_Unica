namespace Master_Details_Ventanilla_Unica.Migrations
{
    using Master_Details_Ventanilla_Unica.DataLayer;
    using Master_Details_Ventanilla_Unica.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames =false
            };

            var roleManager =
                new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ApplicationDbContext()));

            string name = "tescha_201326266@hotmail.com";
            string password = "Hola123*";
            string firstName = "Admin";
            string roleName = "Admin";

            var role = roleManager.FindByName(roleName);

            if (role==null)
            {
                role = new ApplicationRole(roleName);
                var roleResult = roleManager.Create(role);
            }
            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, FirstName = firstName };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            { 
                var result = userManager.AddToRole(user.Id, role.Name);
            }
            //////////////////////////////////////////////////////////
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
