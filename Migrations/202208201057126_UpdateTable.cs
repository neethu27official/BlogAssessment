namespace BlogAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArticleEntities", "Heading");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticleEntities", "Heading", c => c.String());
        }
    }
}
