namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'56cf8409-8a14-4b98-8d5b-967617c478ee', N'admin@vidly.com', 0, N'AAq0ayBZHXSEfsmEfi6JLawLXaas2S7h+Bl/2/aiaEs6hWH3ye+reGsVi5SkE5gX5g==', N'f2af3646-61c5-4f23-b831-b2bfef485222', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7caa135d-13c5-4596-b6a5-99d0c8cf2b79', N'guest@vidly.com', 0, N'ACB8CSlCFVu/liHQZVnrzGmH21Lt1k7ebDe65kBkuCDhqQAE5BPQz/O+X6FQ4Ac5aA==', N'70fad00c-04e9-4391-9f36-efc121143d91', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd7131857-b60b-4fe4-a5c4-f807518e36de', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'56cf8409-8a14-4b98-8d5b-967617c478ee', N'd7131857-b60b-4fe4-a5c4-f807518e36de')
");
        }
        
        public override void Down()
        {
        }
    }
}
