namespace EShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNInvoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerMobile = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                        CustomerBalance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        InvoiceTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        PaymentModeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMode", t => t.PaymentModeID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID)
                .Index(t => t.PaymentModeID);
            
            CreateTable(
                "dbo.InvoiceDetail",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        Qty = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.Invoice", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.PaymentMode",
                c => new
                    {
                        PaymentModeID = c.Int(nullable: false, identity: true),
                        PaymentModeName = c.String(),
                        PaymentModeIsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentModeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "PaymentModeID", "dbo.PaymentMode");
            DropForeignKey("dbo.InvoiceDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.InvoiceDetail", "InvoiceID", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Invoice", "CustomerID", "dbo.Customer");
            DropIndex("dbo.InvoiceDetail", new[] { "ProductID" });
            DropIndex("dbo.InvoiceDetail", new[] { "InvoiceID" });
            DropIndex("dbo.Invoice", new[] { "PaymentModeID" });
            DropIndex("dbo.Invoice", new[] { "EmployeeID" });
            DropIndex("dbo.Invoice", new[] { "CustomerID" });
            DropTable("dbo.PaymentMode");
            DropTable("dbo.InvoiceDetail");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
        }
    }
}
