namespace MyStackOverFlow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateDataTypechnagedinIDbContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AComments", "Comdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Answers", "Ansdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Questions", "Qdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.QComments", "Comdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QComments", "Comdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Questions", "Qdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Answers", "Ansdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AComments", "Comdate", c => c.DateTime(nullable: false));
        }
    }
}
