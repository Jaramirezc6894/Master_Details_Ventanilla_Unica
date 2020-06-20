namespace Master_Details_Ventanilla_Unica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.CategoryName, unique: true, name: "AK_Category_CategoryName");
            
            CreateTable(
                "dbo.DocumentItems",
                c => new
                    {
                        DocumentIteId = c.Int(nullable: false, identity: true),
                        DocumentItemCode = c.String(nullable: false, maxLength: 15),
                        DocumentItemName = c.String(nullable: false, maxLength: 255),
                        FileDocumentItem = c.Binary(nullable: false, maxLength: 2),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentIteId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.DocumentItemCode, unique: true, name: "AK_DocumentItem_DocumentItemCode")
                .Index(t => t.DocumentItemName, unique: true, name: "AK_DocumentItem_DocumentItemName")
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ServiceItems",
                c => new
                    {
                        ServiceItemId = c.Int(nullable: false, identity: true),
                        ServiceItemCode = c.String(nullable: false, maxLength: 15),
                        ServiceItemName = c.String(nullable: false, maxLength: 80),
                        FileServiceItem = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ServiceItemCode, unique: true, name: "AK_ServiceItem_ServiceItemCode")
                .Index(t => t.ServiceItemName, unique: true, name: "AK_ServiceItem_ServiceItemName")
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        AccoutNumber = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        Addres = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 20),
                        State = c.String(nullable: false, maxLength: 10),
                        ZipCode = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CustomerId)
                .Index(t => t.AccoutNumber, unique: true, name: "AK_Customer_AccountNumber");
            
            CreateTable(
                "dbo.Labors",
                c => new
                    {
                        LaborId = c.Int(nullable: false, identity: true),
                        WordOrderId = c.Int(nullable: false),
                        ServiceItemCode = c.String(nullable: false, maxLength: 15),
                        ServiceItemName = c.String(nullable: false, maxLength: 255),
                        LaborHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(maxLength: 255),
                        WorkOrder_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.LaborId)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_WorkOrderId)
                .Index(t => new { t.WordOrderId, t.ServiceItemCode }, unique: true, name: "AK_Labor")
                .Index(t => t.WorkOrder_WorkOrderId);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDateTime = c.DateTime(nullable: false, defaultValueSql: "GetDate()"),
                        TargetDateTime = c.DateTime(),
                        DropDeadDateTime = c.DateTime(),
                        Description = c.String(maxLength: 256),
                        WordOrderStatus = c.Int(nullable: false),
                        CertificationReuirements = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        WordOrderId = c.Int(nullable: false),
                        DocumentItemCode = c.String(nullable: false, maxLength: 15),
                        DocumentItemName = c.String(nullable: false, maxLength: 255),
                        Note = c.String(maxLength: 255),
                        IsInstalled = c.Boolean(nullable: false),
                        WorkOrder_WorkOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.WorkOrders", t => t.WorkOrder_WorkOrderId)
                .Index(t => new { t.WordOrderId, t.DocumentItemCode }, unique: true, name: "AK_Part")
                .Index(t => t.WorkOrder_WorkOrderId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Parts", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.Labors", "WorkOrder_WorkOrderId", "dbo.WorkOrders");
            DropForeignKey("dbo.WorkOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ServiceItems", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.DocumentItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Parts", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.Parts", "AK_Part");
            DropIndex("dbo.WorkOrders", new[] { "CustomerId" });
            DropIndex("dbo.Labors", new[] { "WorkOrder_WorkOrderId" });
            DropIndex("dbo.Labors", "AK_Labor");
            DropIndex("dbo.Customers", "AK_Customer_AccountNumber");
            DropIndex("dbo.ServiceItems", new[] { "CategoryId" });
            DropIndex("dbo.ServiceItems", "AK_ServiceItem_ServiceItemName");
            DropIndex("dbo.ServiceItems", "AK_ServiceItem_ServiceItemCode");
            DropIndex("dbo.DocumentItems", new[] { "CategoryId" });
            DropIndex("dbo.DocumentItems", "AK_DocumentItem_DocumentItemName");
            DropIndex("dbo.DocumentItems", "AK_DocumentItem_DocumentItemCode");
            DropIndex("dbo.Categories", "AK_Category_CategoryName");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Parts");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.Labors");
            DropTable("dbo.Customers");
            DropTable("dbo.ServiceItems");
            DropTable("dbo.DocumentItems");
            DropTable("dbo.Categories");
        }
    }
}
