namespace OMS.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasecreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 30),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        ParentCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_ID)
                .Index(t => t.ParentCategory_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TransactionID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Transactions", t => t.TransactionID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.TransactionID)
                .Index(t => t.ProductID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Addresses", t => t.AddressID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID)
                .Index(t => t.AddressID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressLineOne = c.String(nullable: false, maxLength: 25),
                        AddressLineTwo = c.String(maxLength: 25),
                        City = c.String(nullable: false, maxLength: 25),
                        PostalCode = c.String(maxLength: 10),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        MobileNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 25),
                        Gender = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Address_ID = c.Int(),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        MobileNumber = c.Int(nullable: false),
                        Tin = c.Int(nullable: false),
                        BusinessName = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryVariants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        VariantID = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Variants", t => t.VariantID)
                .Index(t => t.CategoryID)
                .Index(t => t.VariantID);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InventoryLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Note = c.String(),
                        InvoiceNumber = c.Int(nullable: false),
                        Process = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Product_ID = c.Int(nullable: false),
                        Supplier_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        VariantID = c.Int(nullable: false),
                        Value = c.String(),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Variants", t => t.VariantID)
                .Index(t => t.ProductID)
                .Index(t => t.VariantID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        GoodQuantity = c.Int(nullable: false),
                        DamagedQuantity = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.VariantOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VariantID = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Variants", t => t.VariantID)
                .Index(t => t.VariantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VariantOptions", "VariantID", "dbo.Variants");
            DropForeignKey("dbo.Stocks", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductVariants", "VariantID", "dbo.Variants");
            DropForeignKey("dbo.ProductVariants", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InventoryLogs", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.InventoryLogs", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.CategoryVariants", "VariantID", "dbo.Variants");
            DropForeignKey("dbo.CategoryVariants", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Orders", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Orders", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Transactions", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Users", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_ID", "dbo.Categories");
            DropIndex("dbo.VariantOptions", new[] { "VariantID" });
            DropIndex("dbo.Stocks", new[] { "ProductID" });
            DropIndex("dbo.ProductVariants", new[] { "VariantID" });
            DropIndex("dbo.ProductVariants", new[] { "ProductID" });
            DropIndex("dbo.InventoryLogs", new[] { "Supplier_ID" });
            DropIndex("dbo.InventoryLogs", new[] { "Product_ID" });
            DropIndex("dbo.CategoryVariants", new[] { "VariantID" });
            DropIndex("dbo.CategoryVariants", new[] { "CategoryID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Users", new[] { "Address_ID" });
            DropIndex("dbo.Transactions", new[] { "User_ID" });
            DropIndex("dbo.Transactions", new[] { "AddressID" });
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "User_ID" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "TransactionID" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_ID" });
            DropTable("dbo.VariantOptions");
            DropTable("dbo.Stocks");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Suppliers");
            DropTable("dbo.InventoryLogs");
            DropTable("dbo.Variants");
            DropTable("dbo.CategoryVariants");
            DropTable("dbo.Customers");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
            DropTable("dbo.Transactions");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
