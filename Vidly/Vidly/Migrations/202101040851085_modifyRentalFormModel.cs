namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRentalFormModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Byte(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalForms", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.RentalForms", new[] { "Customer_Id" });
            DropTable("dbo.RentalForms");
        }
    }
}
