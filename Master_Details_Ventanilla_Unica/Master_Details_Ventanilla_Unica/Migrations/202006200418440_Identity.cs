namespace Master_Details_Ventanilla_Unica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentItems", "FechaSubida", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceItems", "FechaSubida", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 15));
            CreateIndex("dbo.Customers", "CompanyName", unique: true, name: "AK_Customer_CompanyName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", "AK_Customer_CompanyName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.ServiceItems", "FechaSubida");
            DropColumn("dbo.DocumentItems", "FechaSubida");
        }
    }
}
