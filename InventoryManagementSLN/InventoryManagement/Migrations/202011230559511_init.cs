namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ProductExpDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tSupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.tSuppliers", t => t.tSupplierID, cascadeDelete: true)
                .Index(t => t.tSupplierID);
            
            CreateTable(
                "dbo.tSuppliers",
                c => new
                    {
                        tSupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        MobileNO = c.String(),
                    })
                .PrimaryKey(t => t.tSupplierID);
            
            CreateTable(
                "dbo.tbRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "tSupplierID", "dbo.tSuppliers");
            DropIndex("dbo.tbRoles", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "tSupplierID" });
            DropTable("dbo.Users");
            DropTable("dbo.tbRoles");
            DropTable("dbo.tSuppliers");
            DropTable("dbo.Products");
        }
    }
}
