namespace MyStackOverFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertychangeinQuestionAndAnswerClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "AnsVoteCount", c => c.Int());
            AlterColumn("dbo.Questions", "QVoteCount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "QVoteCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "AnsVoteCount", c => c.Int(nullable: false));
        }
    }
}
