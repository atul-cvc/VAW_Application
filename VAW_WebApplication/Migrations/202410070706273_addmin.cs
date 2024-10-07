namespace VAW_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MinName", c => c.String());
            AddColumn("dbo.AspNetUsers", "OrgCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OrgCode");
            DropColumn("dbo.AspNetUsers", "MinName");
        }
    }
}
