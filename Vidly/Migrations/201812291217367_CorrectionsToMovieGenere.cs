namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionsToMovieGenere : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenereId_Id", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "GenereId_Id" });
            RenameColumn(table: "dbo.Movies", name: "GenereId_Id", newName: "GenereId");
            AlterColumn("dbo.Movies", "GenereId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenereId");
            AddForeignKey("dbo.Movies", "GenereId", "dbo.Generes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenereId", "dbo.Generes");
            DropIndex("dbo.Movies", new[] { "GenereId" });
            AlterColumn("dbo.Movies", "GenereId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "GenereId", newName: "GenereId_Id");
            CreateIndex("dbo.Movies", "GenereId_Id");
            AddForeignKey("dbo.Movies", "GenereId_Id", "dbo.Generes", "Id");
        }
    }
}
