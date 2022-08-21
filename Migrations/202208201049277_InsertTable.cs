namespace BlogAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleEntities",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        LastUpdated = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Heading = c.String(),
                        Author = c.String(),
                        Content = c.String(),
                        Email = c.String(),
                        Mobileno = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleEntities");
        }
    }
}
