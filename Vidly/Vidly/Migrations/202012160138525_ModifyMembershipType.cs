namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMembershipType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MembershipTyps", newName: "MembershipTypes");
            DropForeignKey("dbo.Customers", "MembershipTyp_Id", "dbo.MembershipTyps");
            DropIndex("dbo.Customers", new[] { "MembershipTyp_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTyp_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipTyp_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTyp_Id");
            AddForeignKey("dbo.Customers", "MembershipTyp_Id", "dbo.MembershipTyps", "Id");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipTyps");
        }
    }
}
