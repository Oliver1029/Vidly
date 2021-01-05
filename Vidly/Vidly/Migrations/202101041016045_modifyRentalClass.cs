namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRentalClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentalForms", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RentalForms", new[] { "Customer_Id" });
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movies_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movies_Id);
            
            DropTable("dbo.RentalForms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RentalForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.Rentals");
            CreateIndex("dbo.RentalForms", "Customer_Id");
            AddForeignKey("dbo.RentalForms", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
