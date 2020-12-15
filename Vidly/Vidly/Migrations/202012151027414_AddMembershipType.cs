namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTyps",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipTyp_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTyp_Id");
            AddForeignKey("dbo.Customers", "MembershipTyp_Id", "dbo.MembershipTyps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTyp_Id", "dbo.MembershipTyps");
            DropIndex("dbo.Customers", new[] { "MembershipTyp_Id" });
            DropColumn("dbo.Customers", "MembershipTyp_Id");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropTable("dbo.MembershipTyps");
        }
    }
}
