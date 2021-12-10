namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Steps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Step", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "MaxAmountOfSteps", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
