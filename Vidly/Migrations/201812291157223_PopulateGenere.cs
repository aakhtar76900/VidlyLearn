namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenere : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Generes(Name) Values('Comedey')");
            Sql("Insert into Generes(Name) Values('Action')");
            Sql("Insert into Generes(Name) Values('Thriller')");
            Sql("Insert into Generes(Name) Values('SciFi')");


        }
        
        public override void Down()
        {
        }
    }
}
