namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeerChecker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HaveBeer", c => c.Boolean(nullable: false));

        }

        public override void Down()
        {
        }
    }
}
