namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'66efcace-b709-4455-a4c1-fb377120569c', N'guest@vidly.com', 0, N'AOvQ7loPDXOQmIZWWuKfcT2rcvZm9cwUHvOw+GTPXoVaTwSxoE+zlqgKeXQYVQy8yg==', N'4df029b9-4708-4644-aa2c-cd56c22c7532', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7ac15f1-5b43-4cbf-859d-f7b615837428', N'admin@vidly.com', 0, N'ANsmd7g3JCxA0m9PSpG7/AWf7AoBTJq2mJTM4T8rAFYm/Pk6EcWap4hcq0+H+Y5kig==', N'1c3a092a-971e-4ef4-9fb8-5f8f8a2f2728', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c86d07e-33c7-486d-a60a-cb2f833eb319', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e7ac15f1-5b43-4cbf-859d-f7b615837428', N'7c86d07e-33c7-486d-a60a-cb2f833eb319')

");
        }
        
        public override void Down()
        {
        }
    }
}
