namespace MyStackOverFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdTableCodeAddedInIdentityModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Quest_TagId", "dbo.Quest_Tag");
            DropForeignKey("dbo.Tags", "Quest_TagId", "dbo.Quest_Tag");
            DropIndex("dbo.Questions", new[] { "Quest_TagId" });
            DropIndex("dbo.Tags", new[] { "Quest_TagId" });
            DropPrimaryKey("dbo.Tags");
            CreateTable(
                "dbo.QuestTag",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.TagId })
                .ForeignKey("dbo.Questions", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TagId);
            
          
            DropColumn("dbo.AComments", "Tilte");
            DropColumn("dbo.Answers", "Tilte");
            DropColumn("dbo.Questions", "Quest_TagId");
            DropColumn("dbo.QComments", "Tilte");
            DropColumn("dbo.Tags", "Id");
            DropColumn("dbo.Tags", "Quest_TagId");
            DropTable("dbo.Quest_Tag");
            AddColumn("dbo.Tags", "TagId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tags", "TagId");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Quest_Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tags", "Quest_TagId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QComments", "Tilte", c => c.String());
            AddColumn("dbo.Questions", "Quest_TagId", c => c.Int());
            AddColumn("dbo.Answers", "Tilte", c => c.String());
            AddColumn("dbo.AComments", "Tilte", c => c.String());
            DropForeignKey("dbo.QuestTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.QuestTag", "Id", "dbo.Questions");
            DropIndex("dbo.QuestTag", new[] { "TagId" });
            DropIndex("dbo.QuestTag", new[] { "Id" });
            DropPrimaryKey("dbo.Tags");
            DropColumn("dbo.Tags", "TagId");
            DropTable("dbo.QuestTag");
            AddPrimaryKey("dbo.Tags", "Id");
            CreateIndex("dbo.Tags", "Quest_TagId");
            CreateIndex("dbo.Questions", "Quest_TagId");
            AddForeignKey("dbo.Tags", "Quest_TagId", "dbo.Quest_Tag", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Quest_TagId", "dbo.Quest_Tag", "Id");
        }
    }
}
