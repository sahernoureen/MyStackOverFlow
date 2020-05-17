namespace MyStackOverFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReputationAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Badge", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Badge");
        }
    }
}
