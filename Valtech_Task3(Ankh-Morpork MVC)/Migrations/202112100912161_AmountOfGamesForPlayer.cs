namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmountOfGamesForPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AmountOfGames", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AmountOfGames");
        }
    }
}
