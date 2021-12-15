using System.Data.Entity.Migrations;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Migrations
{
    public partial class RenameColoumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.AspNetUsers", "HaveBeer", "HasBeer");
        }
        
        public override void Down()
        {
        }
    }
}
