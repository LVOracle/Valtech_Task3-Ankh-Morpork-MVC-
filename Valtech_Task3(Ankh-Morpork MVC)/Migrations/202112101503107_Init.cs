namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers","AmountOfBeer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
