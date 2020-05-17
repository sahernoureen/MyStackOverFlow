namespace MyStackOverFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tilte = c.String(),
                        Description = c.String(),
                        Comdate = c.DateTime(nullable: false),
                        AnswerId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AnswerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tilte = c.String(),
                        Description = c.String(),
                        Ansdate = c.DateTime(nullable: false),
                        AnsVoteCount = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.UserId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tilte = c.String(),
                        Description = c.String(),
                        Qdate = c.DateTime(nullable: false),
                        QVoteCount = c.Int(nullable: false),
                        Quest_TagId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.Quest_Tag", t => t.Quest_TagId)
                .Index(t => t.Quest_TagId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tilte = c.String(),
                        Description = c.String(),
                        Comdate = c.DateTime(nullable: false),
                        QuestionId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Reputation = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Quest_Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Quest_TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quest_Tag", t => t.Quest_TagId, cascadeDelete: true)
                .Index(t => t.Quest_TagId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpVote = c.Boolean(nullable: false),
                        DownVote = c.Boolean(nullable: false),
                        QuestionId = c.Int(),
                        AnswerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.AComments", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AComments", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Votes", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Votes", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Tags", "Quest_TagId", "dbo.Quest_Tag");
            DropForeignKey("dbo.Questions", "Quest_TagId", "dbo.Quest_Tag");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Questions", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.QComments", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Answers", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.QComments", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Votes", new[] { "AnswerId" });
            DropIndex("dbo.Votes", new[] { "QuestionId" });
            DropIndex("dbo.Tags", new[] { "Quest_TagId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QComments", new[] { "UserId" });
            DropIndex("dbo.QComments", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "Quest_TagId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "UserId" });
            DropIndex("dbo.AComments", new[] { "UserId" });
            DropIndex("dbo.AComments", new[] { "AnswerId" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Votes");
            DropTable("dbo.Tags");
            DropTable("dbo.Quest_Tag");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.QComments");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.AComments");
        }
    }
}
