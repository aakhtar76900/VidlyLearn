namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenereTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenereId_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenereId_Id");
            AddForeignKey("dbo.Movies", "GenereId_Id", "dbo.Generes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenereId_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "GenereId_Id" });
            DropColumn("dbo.Movies", "GenereId_Id");
            DropTable("dbo.Generes");
        }
    }
}
