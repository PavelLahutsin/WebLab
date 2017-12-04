using System.Data.Entity.Migrations;

namespace _60322_1_Lagutin.Migrations
{
    public partial class Nick : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NickName");
        }
    }
}
